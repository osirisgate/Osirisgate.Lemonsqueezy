using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Price.ValueObject;

/// <summary>
/// Represents a tier in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class Tier
{
    /// <summary>Gets the last unit.</summary>
    [JsonPropertyName("last_unit")]
    public int LastUnit { get; init; } = default;

    /// <summary>Gets the unit price.</summary>
    [JsonPropertyName("unit_price")]
    public int? UnitPrice { get; init; } = null;

    /// <summary>Gets the unit price decimal.</summary>
    [JsonPropertyName("unit_price_decimal")]
    public decimal? UnitPriceDecimal { get; init; } = null;

    /// <summary>Gets the fixed fee.</summary>
    [JsonPropertyName("fixed_fee")]
    public int FixedFee { get; init; } = default;
}
