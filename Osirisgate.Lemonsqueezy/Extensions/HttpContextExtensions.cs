using Microsoft.AspNetCore.Http;
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Middleware;

namespace Osirisgate.Lemonsqueezy.Extensions;

/// <summary>
/// Extension methods for accessing webhook content from HttpContext.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class HttpContextExtensions
{
    /// <summary>
    /// Gets the Lemonsqueezy raw webhook body from the HttpContext, throwing an exception if not available.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>The raw webhook body as a string.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the webhook body is not available.</exception>
    public static string GetLemonsqueezyWebhookRawBody(this HttpContext context)
    {
        return context.GetWebhookRawBody() ?? throw new Exception.InvalidOperationException(new Dictionary<string, object>
        {
            ["message"] = "Webhook body not available. Ensure UseLemonsqueezyWebhookValidation() is called in the pipeline.",
            ["details"] = new Dictionary<string, object>
            {
                ["middlewareKey"] = WebhookValidationMiddleware.WebhookRawBodyKey
            }
        });
    }

    /// <summary>
    /// Deserializes the Lemonsqueezy webhook payload from the HttpContext, throwing an exception if not available.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>The deserialized webhook payload.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the webhook body is not available.</exception>
    public static WebhookPayload GetLemonsqueezyWebhookPayload(this HttpContext context)
    {
        var rawBody = context.GetLemonsqueezyWebhookRawBody();
        return WebhookPayloadDeserializer.Deserialize(rawBody);
    }

    /// <summary>
    /// Gets the raw webhook body from the HttpContext.
    /// The body is stored by the WebhookValidationMiddleware after signature validation.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>The raw webhook body as a string, or null if not available.</returns>
    private static string? GetWebhookRawBody(this HttpContext context)
    {
        if (context.Items.TryGetValue(WebhookValidationMiddleware.WebhookRawBodyKey, out var rawBodyObj) &&
            rawBodyObj is string rawBody)
        {
            return rawBody;
        }

        return null;
    }
}
