using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;

/// <summary>
/// Represents the API response for a order items relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderItemsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<OrderItemResponseData> Data { get; init; } = [];
}
