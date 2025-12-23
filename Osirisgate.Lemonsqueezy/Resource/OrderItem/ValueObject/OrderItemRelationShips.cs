using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.OrderItem.ValueObject;

/// <summary>
/// Represents the relationship links for a order item.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderItemRelationShips
{
    /// <summary>Gets the order.</summary>
    [JsonPropertyName("order")]
    public RelationShipLink Order { get; init; } = new();

    /// <summary>Gets the product.</summary>
    [JsonPropertyName("product")]
    public RelationShipLink Product { get; init; } = new();

    /// <summary>Gets the variant.</summary>
    [JsonPropertyName("variant")]
    public RelationShipLink Variant { get; init; } = new();
}
