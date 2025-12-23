using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.SubscriptionItem;

/// <summary>
/// Represents the attributes of a subscription item.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionItemAttributes
{
    /// <summary>Gets the subscription id.</summary>
    [JsonPropertyName("subscription_id")]
    public int SubscriptionId { get; init; } = default;

    /// <summary>Gets the price id.</summary>
    [JsonPropertyName("price_id")]
    public int PriceId { get; init; } = default;

    /// <summary>Gets the quantity.</summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; } = default;

    /// <summary>Gets the is usage based.</summary>
    [JsonPropertyName("is_usage_based")]
    public bool IsUsageBased { get; init; } = false;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
