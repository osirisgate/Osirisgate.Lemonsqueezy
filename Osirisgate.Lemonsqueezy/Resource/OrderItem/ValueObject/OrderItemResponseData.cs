using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.OrderItem.ValueObject;

/// <summary>
/// Represents the API response for a order item data.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderItemResponseData : Model.OrderItem.OrderItem
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the relation ships.</summary>
    [JsonPropertyName("relationships")]
    public OrderItemRelationShips RelationShips { get; init; } = new();
}
