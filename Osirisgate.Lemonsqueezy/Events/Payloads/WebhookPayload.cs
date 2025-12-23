using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Events.Payloads;

/// <summary>
/// Base class for webhook event payloads.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class WebhookPayload
{
    /// <summary>Gets the event metadata.</summary>
    [JsonPropertyName("meta")]
    public WebhookEventMeta Meta { get; init; } = new();
}
