using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Discount;

/// <summary>
/// Represents the attributes of a discount.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the code.</summary>
    [JsonPropertyName("code")]
    public string Code { get; init; } = string.Empty;

    /// <summary>Gets the amount.</summary>
    [JsonPropertyName("amount")]
    public int Amount { get; init; } = default;

    /// <summary>Gets the amount type.</summary>
    [JsonPropertyName("amount_type")]
    public string AmountType { get; init; } = string.Empty;

    /// <summary>Gets the is limited to products.</summary>
    [JsonPropertyName("is_limited_to_products")]
    public bool IsLimitedToProducts { get; init; } = false;

    /// <summary>Gets the is limited redemptions.</summary>
    [JsonPropertyName("is_limited_redemptions")]
    public bool IsLimitedRedemptions { get; init; } = false;

    /// <summary>Gets the max redemptions.</summary>
    [JsonPropertyName("max_redemptions")]
    public int MaxRedemptions { get; init; } = default;

    /// <summary>Gets the starts at.</summary>
    [JsonPropertyName("starts_at")]
    public string? StartsAt { get; init; } = null;

    /// <summary>Gets the expires at.</summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; init; } = null;

    /// <summary>Gets the duration.</summary>
    [JsonPropertyName("duration")]
    public string Duration { get; init; } = string.Empty;

    /// <summary>Gets the duration in months.</summary>
    [JsonPropertyName("duration_in_months")]
    public int DurationInMonths { get; init; } = default;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;

    /// <summary>Gets the test mode.</summary>
    [JsonPropertyName("test_mode")]
    public bool TestMode { get; init; } = false;
}
