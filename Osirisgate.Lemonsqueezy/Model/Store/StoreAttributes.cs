using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Store;

/// <summary>
/// Represents the attributes of a store.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class StoreAttributes
{
    /// <summary>Gets the store name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the store slug.</summary>
    [JsonPropertyName("slug")]
    public string Slug { get; init; } = string.Empty;

    /// <summary>Gets the store domain.</summary>
    [JsonPropertyName("domain")]
    public string Domain { get; init; } = string.Empty;

    /// <summary>Gets the store URL.</summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;

    /// <summary>Gets the avatar URL.</summary>
    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; init; } = string.Empty;

    /// <summary>Gets the subscription plan.</summary>
    [JsonPropertyName("plan")]
    public string Plan { get; init; } = string.Empty;

    /// <summary>Gets the country code.</summary>
    [JsonPropertyName("country")]
    public string Country { get; init; } = string.Empty;

    /// <summary>Gets the country display name.</summary>
    [JsonPropertyName("country_nicename")]
    public string CountryNicename { get; init; } = string.Empty;

    /// <summary>Gets the currency code.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; init; } = string.Empty;

    /// <summary>Gets the total number of sales.</summary>
    [JsonPropertyName("total_sales")]
    public int TotalSales { get; init; } = default;

    /// <summary>Gets the total revenue amount.</summary>
    [JsonPropertyName("total_revenue")]
    public int TotalRevenue { get; init; } = default;

    /// <summary>Gets the sales in the last 30 days.</summary>
    [JsonPropertyName("thirty_day_sales")]
    public int ThirtyDaySales { get; init; } = default;

    /// <summary>Gets the revenue in the last 30 days.</summary>
    [JsonPropertyName("thirty_day_revenue")]
    public int ThirtyDayRevenue { get; init; } = default;

    /// <summary>Gets the creation timestamp.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the last update timestamp.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
