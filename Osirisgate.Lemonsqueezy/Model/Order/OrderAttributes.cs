using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.Order.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Order;

/// <summary>
/// Represents the attributes of a order.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the customer id.</summary>
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; init; } = default;

    /// <summary>Gets the identifier.</summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; } = string.Empty;

    /// <summary>Gets the order number.</summary>
    [JsonPropertyName("order_number")]
    public int OrderNumber { get; init; } = default;

    /// <summary>Gets the user name.</summary>
    [JsonPropertyName("user_name")]
    public string UserName { get; init; } = string.Empty;

    /// <summary>Gets the user email.</summary>
    [JsonPropertyName("user_email")]
    public string UserEmail { get; init; } = string.Empty;

    /// <summary>Gets the currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; init; } = string.Empty;

    /// <summary>Gets the currency rate.</summary>
    [JsonPropertyName("currency_rate")]
    public string CurrencyRate { get; init; } = string.Empty;

    /// <summary>Gets the subtotal.</summary>
    [JsonPropertyName("subtotal")]
    public int Subtotal { get; init; } = default;

    /// <summary>Gets the setup fee.</summary>
    [JsonPropertyName("setup_fee")]
    public int SetupFee { get; init; } = default;

    /// <summary>Gets the discount total.</summary>
    [JsonPropertyName("discount_total")]
    public int DiscountTotal { get; init; } = default;

    /// <summary>Gets the tax.</summary>
    [JsonPropertyName("tax")]
    public int Tax { get; init; } = default;

    /// <summary>Gets the total.</summary>
    [JsonPropertyName("total")]
    public int Total { get; init; } = default;

    /// <summary>Gets the subtotal usd.</summary>
    [JsonPropertyName("subtotal_usd")]
    public int SubtotalUsd { get; init; } = default;

    /// <summary>Gets the setup fee usd.</summary>
    [JsonPropertyName("setup_fee_usd")]
    public int SetupFeeUsd { get; init; } = default;

    /// <summary>Gets the discount total usd.</summary>
    [JsonPropertyName("discount_total_usd")]
    public int DiscountTotalUsd { get; init; } = default;

    /// <summary>Gets the tax usd.</summary>
    [JsonPropertyName("tax_usd")]
    public int TaxUsd { get; init; } = default;

    /// <summary>Gets the total usd.</summary>
    [JsonPropertyName("total_usd")]
    public int TotalUsd { get; init; } = default;

    /// <summary>Gets the tax name.</summary>
    [JsonPropertyName("tax_name")]
    public string TaxName { get; init; } = string.Empty;

    /// <summary>Gets the tax rate.</summary>
    [JsonPropertyName("tax_rate")]
    public string TaxRate { get; init; } = string.Empty;

    /// <summary>Gets the tax inclusive.</summary>
    [JsonPropertyName("tax_inclusive")]
    public bool TaxInclusive { get; init; } = false;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

    /// <summary>Gets the refunded.</summary>
    [JsonPropertyName("refunded")]
    public bool Refunded { get; init; } = false;

    /// <summary>Gets the refunded at.</summary>
    [JsonPropertyName("refunded_at")]
    public string? RefundedAt { get; init; } = null;

    /// <summary>Gets the subtotal formatted.</summary>
    [JsonPropertyName("subtotal_formatted")]
    public string SubtotalFormatted { get; init; } = string.Empty;

    /// <summary>Gets the setup fee formatted.</summary>
    [JsonPropertyName("setup_fee_formatted")]
    public string SetupFeeFormatted { get; init; } = string.Empty;

    /// <summary>Gets the discount total formatted.</summary>
    [JsonPropertyName("discount_total_formatted")]
    public string DiscountTotalFormatted { get; init; } = string.Empty;

    /// <summary>Gets the tax formatted.</summary>
    [JsonPropertyName("tax_formatted")]
    public string TaxFormatted { get; init; } = string.Empty;

    /// <summary>Gets the total formatted.</summary>
    [JsonPropertyName("total_formatted")]
    public string TotalFormatted { get; init; } = string.Empty;

    /// <summary>Gets the first order item.</summary>
    [JsonPropertyName("first_order_item")]
    public FirstOrderItem FirstOrderItem { get; init; } = new();

    /// <summary>Gets the urls.</summary>
    [JsonPropertyName("urls")]
    public ReceiptUrl Urls { get; init; } = new();

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
