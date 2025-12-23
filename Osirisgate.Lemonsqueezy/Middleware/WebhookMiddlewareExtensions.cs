using Microsoft.AspNetCore.Builder;

namespace Osirisgate.Lemonsqueezy.Middleware;

/// <summary>
/// Extension methods for configuring webhook validation middleware.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class WebhookMiddlewareExtensions
{
    /// <summary>
    /// Adds the webhook validation middleware to the application pipeline.
    /// The middleware validates webhook signatures for requests to webhook endpoints.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="webhookPathPrefix">Optional webhook path prefix. Defaults to "/v1/webhooks".</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseLemonsqueezyWebhookValidation(
        this IApplicationBuilder app,
        string? webhookPathPrefix = null)
    {
        if (webhookPathPrefix == null)
        {
            return app.UseMiddleware<WebhookValidationMiddleware>();
        }

        return app.UseMiddleware<WebhookValidationMiddleware>(webhookPathPrefix);
    }
}
