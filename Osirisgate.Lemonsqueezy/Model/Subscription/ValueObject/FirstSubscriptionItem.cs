using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Subscription.ValueObject;

/// <summary>
/// Represents a first subscription item in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class FirstSubscriptionItem
{
    /// <summary>Gets the id.</summary>
    [JsonPropertyName("id")]
    public int Id { get; init; } = default;

    /// <summary>Gets the subscription id.</summary>
    [JsonPropertyName("subscription_id")]
    public int SubscriptionId { get; init; } = default;

    /// <summary>Gets the price id.</summary>
    [JsonPropertyName("price_id")]
    public int PriceId { get; init; } = default;

    /// <summary>Gets the quantity.</summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; } = default;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
