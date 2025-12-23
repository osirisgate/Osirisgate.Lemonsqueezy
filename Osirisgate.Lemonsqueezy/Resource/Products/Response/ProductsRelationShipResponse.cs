using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Products.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Products.Response;

/// <summary>
/// Represents the API response for a products relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ProductsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<ProductResponseData> Data { get; init; } = [];
}
