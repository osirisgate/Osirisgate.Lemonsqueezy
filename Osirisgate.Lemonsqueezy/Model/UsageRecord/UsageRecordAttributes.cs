using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.UsageRecord;

/// <summary>
/// Represents the attributes of a usage record.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UsageRecordAttributes
{
    /// <summary>Gets the subscription item id.</summary>
    [JsonPropertyName("subscription_item_id")]
    public int SubscriptionItemId { get; init; } = default;

    /// <summary>Gets the quantity.</summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; } = default;

    /// <summary>Gets the action.</summary>
    [JsonPropertyName("action")]
    public string Action { get; init; } = string.Empty;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
