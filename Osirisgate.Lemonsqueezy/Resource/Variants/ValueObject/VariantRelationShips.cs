using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Variants.ValueObject;

/// <summary>
/// Represents the relationship links for a variant.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class VariantRelationShips
{
    /// <summary>Gets the product.</summary>
    [JsonPropertyName("product")]
    public RelationShipLink Product { get; init; } = new();

    /// <summary>Gets the files.</summary>
    [JsonPropertyName("files")]
    public RelationShipLink Files { get; init; } = new();

    /// <summary>Gets the price model.</summary>
    [JsonPropertyName("price-model")]
    public RelationShipLink PriceModel { get; init; } = new();
}
