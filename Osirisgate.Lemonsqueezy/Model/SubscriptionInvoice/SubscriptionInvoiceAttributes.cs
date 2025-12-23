using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.SubscriptionInvoice.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.SubscriptionInvoice;

/// <summary>
/// Represents the attributes of a subscription invoice.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionInvoiceAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the subscription id.</summary>
    [JsonPropertyName("subscription_id")]
    public int SubscriptionId { get; init; } = default;

    /// <summary>Gets the customer id.</summary>
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; init; } = default;

    /// <summary>Gets the user name.</summary>
    [JsonPropertyName("user_name")]
    public string UserName { get; init; } = string.Empty;

    /// <summary>Gets the user email.</summary>
    [JsonPropertyName("user_email")]
    public string UserEmail { get; init; } = string.Empty;

    /// <summary>Gets the billing reason.</summary>
    [JsonPropertyName("billing_reason")]
    public string BillingReason { get; init; } = string.Empty;

    /// <summary>Gets the card brand.</summary>
    [JsonPropertyName("card_brand")]
    public string CardBrand { get; init; } = string.Empty;

    /// <summary>Gets the card last four.</summary>
    [JsonPropertyName("card_last_four")]
    public string CardLastFour { get; init; } = string.Empty;

    /// <summary>Gets the currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; init; } = string.Empty;

    /// <summary>Gets the currency rate.</summary>
    [JsonPropertyName("currency_rate")]
    public string CurrencyRate { get; init; } = string.Empty;

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

    /// <summary>Gets the subtotal.</summary>
    [JsonPropertyName("subtotal")]
    public int Subtotal { get; init; } = default;

    /// <summary>Gets the discount total.</summary>
    [JsonPropertyName("discount_total")]
    public int DiscountTotal { get; init; } = default;

    /// <summary>Gets the tax.</summary>
    [JsonPropertyName("tax")]
    public int Tax { get; init; } = default;

    /// <summary>Gets the tax inclusive.</summary>
    [JsonPropertyName("tax_inclusive")]
    public bool TaxInclusive { get; init; } = false;

    /// <summary>Gets the total.</summary>
    [JsonPropertyName("total")]
    public int Total { get; init; } = default;

    /// <summary>Gets the refunded amount.</summary>
    [JsonPropertyName("refunded_amount")]
    public int RefundedAmount { get; init; } = default;

    /// <summary>Gets the subtotal usd.</summary>
    [JsonPropertyName("subtotal_usd")]
    public int SubtotalUsd { get; init; } = default;

    /// <summary>Gets the discount total usd.</summary>
    [JsonPropertyName("discount_total_usd")]
    public int DiscountTotalUsd { get; init; } = default;

    /// <summary>Gets the tax usd.</summary>
    [JsonPropertyName("tax_usd")]
    public int TaxUsd { get; init; } = default;

    /// <summary>Gets the total usd.</summary>
    [JsonPropertyName("total_usd")]
    public int TotalUsd { get; init; } = default;

    /// <summary>Gets the refunded amount usd.</summary>
    [JsonPropertyName("refunded_amount_usd")]
    public int RefundedAmountUsd { get; init; } = default;

    /// <summary>Gets the subtotal formatted.</summary>
    [JsonPropertyName("subtotal_formatted")]
    public string SubtotalFormatted { get; init; } = string.Empty;

    /// <summary>Gets the discount total formatted.</summary>
    [JsonPropertyName("discount_total_formatted")]
    public string DiscountTotalFormatted { get; init; } = string.Empty;

    /// <summary>Gets the tax formatted.</summary>
    [JsonPropertyName("tax_formatted")]
    public string TaxFormatted { get; init; } = string.Empty;

    /// <summary>Gets the total formatted.</summary>
    [JsonPropertyName("total_formatted")]
    public string TotalFormatted { get; init; } = string.Empty;

    /// <summary>Gets the refunded amount formatted.</summary>
    [JsonPropertyName("refunded_amount_formatted")]
    public string RefundedAmountFormatted { get; init; } = string.Empty;

    /// <summary>Gets the urls.</summary>
    [JsonPropertyName("urls")]
    public InvoiceUrls Urls { get; init; } = new();

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
