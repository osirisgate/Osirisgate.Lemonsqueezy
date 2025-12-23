using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Orders.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Orders.Response;

/// <summary>
/// Represents the API response for a orders relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrdersRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<OrderResponseData> Data { get; init; } = [];
}
