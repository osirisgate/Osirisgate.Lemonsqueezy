using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.Price.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Price;

/// <summary>
/// Represents the attributes of a price.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class PriceAttributes
{
    /// <summary>Gets the variant id.</summary>
    [JsonPropertyName("variant_id")]
    public int VariantId { get; init; } = default;

    /// <summary>Gets the category.</summary>
    [JsonPropertyName("category")]
    public string Category { get; init; } = string.Empty;

    /// <summary>Gets the scheme.</summary>
    [JsonPropertyName("scheme")]
    public string Scheme { get; init; } = string.Empty;

    /// <summary>Gets the usage aggregation.</summary>
    [JsonPropertyName("usage_aggregation")]
    public string? UsageAggregation { get; init; } = null;

    /// <summary>Gets the unit price.</summary>
    [JsonPropertyName("unit_price")]
    public int? UnitPrice { get; init; } = null;

    /// <summary>Gets the unit price decimal.</summary>
    [JsonPropertyName("unit_price_decimal")]
    public decimal? UnitPriceDecimal { get; init; } = null;

    /// <summary>Gets the setup fee enabled.</summary>
    [JsonPropertyName("setup_fee_enabled")]
    public bool? SetupFeeEnabled { get; init; } = null;

    /// <summary>Gets the setup fee.</summary>
    [JsonPropertyName("setup_fee")]
    public int? SetupFee { get; init; } = null;

    /// <summary>Gets the package size.</summary>
    [JsonPropertyName("package_size")]
    public int PackageSize { get; init; } = default;

    /// <summary>Gets the tiers.</summary>
    [JsonPropertyName("tiers")]
    public List<Tier>? Tiers { get; init; } = null;

    /// <summary>Gets the renewal interval unit.</summary>
    [JsonPropertyName("renewal_interval_unit")]
    public string? RenewalIntervalUnit { get; init; } = null;

    /// <summary>Gets the renewal interval quantity.</summary>
    [JsonPropertyName("renewal_interval_quantity")]
    public int? RenewalIntervalQuantity { get; init; } = null;

    /// <summary>Gets the trial interval unit.</summary>
    [JsonPropertyName("trial_interval_unit")]
    public string? TrialIntervalUnit { get; init; } = null;

    /// <summary>Gets the trial interval quantity.</summary>
    [JsonPropertyName("trial_interval_quantity")]
    public int? TrialIntervalQuantity { get; init; } = null;

    /// <summary>Gets the min price.</summary>
    [JsonPropertyName("min_price")]
    public int? MinPrice { get; init; } = null;

    /// <summary>Gets the suggested price.</summary>
    [JsonPropertyName("suggested_price")]
    public int? SuggestedPrice { get; init; } = null;

    /// <summary>Gets the tax code.</summary>
    [JsonPropertyName("tax_code")]
    public string TaxCode { get; init; } = string.Empty;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
