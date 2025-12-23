using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Osirisgate.Lemonsqueezy.Enums;
using Osirisgate.Lemonsqueezy.Events.Webhook;
using System.Text;

namespace Osirisgate.Lemonsqueezy.Middleware;

/// <summary>
/// Middleware for automatically validating webhook signatures from Lemonsqueezy.
/// </summary>
/// <remarks>
/// This middleware validates webhook signatures for requests to webhook endpoints.
/// The raw body is stored in HttpContext.Items["LemonsqueezyWebhookRawBody"] for controller access.
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
/// <param name="next">The next middleware in the pipeline.</param>
/// <param name="validator">The webhook signature validator.</param>
/// <param name="logger">Optional logger instance.</param>
/// <param name="webhookPathPrefix">Optional webhook path prefix. Defaults to "/webhooks".</param>
public sealed class WebhookValidationMiddleware(
    RequestDelegate next,
    IWebhookSignatureValidator validator,
    ILogger<WebhookValidationMiddleware>? logger = null,
    string? webhookPathPrefix = null
)
{
    /// <summary>
    /// The key used to store the raw webhook body in HttpContext.Items.
    /// </summary>
    public const string WebhookRawBodyKey = "LemonsqueezyWebhookRawBody";

    /// <summary>
    /// Default webhook path prefix.
    /// </summary>
    public const string DefaultWebhookPathPrefix = "/webhooks";

    private const string SignatureHeaderName = "X-Signature";
    private const int StreamBufferSize = 1024;

    private readonly RequestDelegate _next = next;
    private readonly IWebhookSignatureValidator _validator = validator;
    private readonly ILogger<WebhookValidationMiddleware>? _logger = logger;
    private readonly string _webhookPathPrefix = webhookPathPrefix ?? DefaultWebhookPathPrefix;

    /// <summary>
    /// Invokes the middleware to validate webhook signatures.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        if (!IsWebhookEndpoint(context.Request.Path))
        {
            await _next(context);
            return;
        }

        var validationResult = await ValidateWebhookRequestAsync(context);

        if (!validationResult.IsValid)
        {
            await WriteErrorResponseAsync(context, validationResult.StatusCode, validationResult.ErrorMessage);
            return;
        }

        await _next(context);
    }

    private bool IsWebhookEndpoint(PathString path)
    {
        return path.StartsWithSegments(_webhookPathPrefix);
    }

    private async Task<ValidationResult> ValidateWebhookRequestAsync(HttpContext context)
    {
        context.Request.EnableBuffering();

        var rawBody = await ReadRequestBodyAsync(context);
        if (rawBody == null)
        {
            return ValidationResult.Invalid(StatusCode.BadRequest.GetValue(), "Error reading request body");
        }

        if (!TryGetSignature(context, out var signature))
        {
            LogMissingSignature(context);
            return ValidationResult.Invalid(StatusCode.Unauthorized.GetValue(), "Missing signature");
        }

        if (!_validator.ValidateSignature(rawBody, signature))
        {
            LogInvalidSignature(context);
            return ValidationResult.Invalid(StatusCode.Unauthorized.GetValue(), "Invalid signature");
        }

        StoreRawBody(context, rawBody);
        return ValidationResult.Valid();
    }

    private async Task<string?> ReadRequestBodyAsync(HttpContext context)
    {
        try
        {
            using var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                leaveOpen: true,
                bufferSize: StreamBufferSize,
                detectEncodingFromByteOrderMarks: false);

            var rawBody = await reader.ReadToEndAsync();

            context.Request.Body.Seek(0, SeekOrigin.Begin);

            return rawBody;
        }
        catch (System.Exception ex)
        {
            _logger?.LogError(ex, "Error reading webhook request body");
            return null;
        }
    }

    private static bool TryGetSignature(HttpContext context, out string signature)
    {
        if (context.Request.Headers.TryGetValue(SignatureHeaderName, out var signatureValue))
        {
            signature = signatureValue.ToString();
            return !string.IsNullOrEmpty(signature);
        }

        signature = string.Empty;
        return false;
    }

    private void LogMissingSignature(HttpContext context)
    {
        if (_logger?.IsEnabled(LogLevel.Warning) == true)
        {
            _logger.LogWarning(
                "Missing {HeaderName} header from {RemoteIp}",
                SignatureHeaderName,
                context.Connection.RemoteIpAddress);
        }
    }

    private void LogInvalidSignature(HttpContext context)
    {
        if (_logger?.IsEnabled(LogLevel.Warning) == true)
        {
            _logger.LogWarning(
                "Invalid webhook signature from {RemoteIp}",
                context.Connection.RemoteIpAddress);
        }
    }

    private static void StoreRawBody(HttpContext context, string rawBody)
    {
        context.Items[WebhookRawBodyKey] = rawBody;
    }

    private static async Task WriteErrorResponseAsync(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(message);
    }

    private sealed class ValidationResult
    {
        public bool IsValid { get; private init; }
        public int StatusCode { get; private init; }
        public string ErrorMessage { get; private init; } = string.Empty;

        private ValidationResult(bool isValid, int statusCode = 0, string errorMessage = "")
        {
            IsValid = isValid;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Valid() => new(true);

        public static ValidationResult Invalid(int statusCode, string errorMessage) =>
            new(false, statusCode, errorMessage);
    }
}
