using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Events;

/// <summary>
/// Represents the metadata for a webhook event payload.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class WebhookEventMeta
{
    /// <summary>Gets whether the webhook is in test mode.</summary>
    [JsonPropertyName("test_mode")]
    public bool TestMode { get; init; } = false;

    /// <summary>Gets the event name.</summary>
    [JsonPropertyName("event_name")]
    public string EventName { get; init; } = string.Empty;

    /// <summary>Gets the webhook ID.</summary>
    [JsonPropertyName("webhook_id")]
    public string WebhookId { get; init; } = string.Empty;

    /// <summary>Gets the custom data associated with the webhook event. This is a dynamic dictionary where fields are not known in advance.</summary>
    [JsonPropertyName("custom_data")]
    public Dictionary<string, object> CustomData { get; init; } = [];
}
