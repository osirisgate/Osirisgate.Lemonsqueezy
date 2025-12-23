using Osirisgate.Lemonsqueezy.Events;

namespace Osirisgate.Lemonsqueezy.Events.Payloads;

/// <summary>
/// Extension methods for WebhookPayload.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class WebhookPayloadExtensions
{
    /// <summary>
    /// Gets the Lemonsqueezy webhook event type from the payload.
    /// </summary>
    /// <param name="payload">The webhook payload.</param>
    /// <returns>The webhook event type.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the event name is unknown.</exception>
    public static WebhookEvent GetEventType(this WebhookPayload payload)
    {
        return WebhookEventExtensions.FromValue(payload.Meta.EventName);
    }
}
