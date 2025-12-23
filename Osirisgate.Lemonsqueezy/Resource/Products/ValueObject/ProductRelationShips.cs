using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Products.ValueObject;

/// <summary>
/// Represents the relationship links for a product.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ProductRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();

    /// <summary>Gets the variants.</summary>
    [JsonPropertyName("variants")]
    public RelationShipLink Variants { get; init; } = new();
}
