using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Webhook;

/// <summary>
/// Represents the attributes of a webhook.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class WebhookAttributes
{
    /// <summary>Gets the store ID.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the webhook URL.</summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;

    /// <summary>Gets the list of subscribed events.</summary>
    [JsonPropertyName("events")]
    public List<string> Events { get; init; } = [];

    /// <summary>Gets the last sent timestamp.</summary>
    [JsonPropertyName("last_sent_at")]
    public string? LastSentAt { get; init; } = null;

    /// <summary>Gets the creation timestamp.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the last update timestamp.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;

    /// <summary>Gets whether test mode is enabled.</summary>
    [JsonPropertyName("test_mode")]
    public bool TestMode { get; init; } = false;
}
