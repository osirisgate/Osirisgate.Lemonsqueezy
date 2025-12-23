using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Checkout.ValueObject;

/// <summary>
/// Represents a preview in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class Preview
{
    /// <summary>Gets the currency.</summary>
    [JsonPropertyName("currency")]
    public string Currency { get; init; } = string.Empty;

    /// <summary>Gets the currency rate.</summary>
    [JsonPropertyName("currency_rate")]
    public double CurrencyRate { get; init; } = default;

    /// <summary>Gets the subtotal.</summary>
    [JsonPropertyName("subtotal")]
    public int Subtotal { get; init; } = default;

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

    /// <summary>Gets the discount total usd.</summary>
    [JsonPropertyName("discount_total_usd")]
    public int DiscountTotalUsd { get; init; } = default;

    /// <summary>Gets the tax usd.</summary>
    [JsonPropertyName("tax_usd")]
    public int TaxUsd { get; init; } = default;

    /// <summary>Gets the total usd.</summary>
    [JsonPropertyName("total_usd")]
    public int TotalUsd { get; init; } = default;

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
}
