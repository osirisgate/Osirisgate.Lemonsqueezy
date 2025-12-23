using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.DiscountRedemption;

/// <summary>
/// Represents the attributes of a discount redemption.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountRedemptionAttributes
{
    /// <summary>Gets the discount id.</summary>
    [JsonPropertyName("discount_id")]
    public int DiscountId { get; init; } = default;

    /// <summary>Gets the order id.</summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; init; } = default;

    /// <summary>Gets the discount name.</summary>
    [JsonPropertyName("discount_name")]
    public string DiscountName { get; init; } = string.Empty;

    /// <summary>Gets the discount code.</summary>
    [JsonPropertyName("discount_code")]
    public string DiscountCode { get; init; } = string.Empty;

    /// <summary>Gets the discount amount.</summary>
    [JsonPropertyName("discount_amount")]
    public int DiscountAmount { get; init; } = default;

    /// <summary>Gets the discount amount type.</summary>
    [JsonPropertyName("discount_amount_type")]
    public string DiscountAmountType { get; init; } = string.Empty;

    /// <summary>Gets the amount.</summary>
    [JsonPropertyName("amount")]
    public int Amount { get; init; } = default;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
