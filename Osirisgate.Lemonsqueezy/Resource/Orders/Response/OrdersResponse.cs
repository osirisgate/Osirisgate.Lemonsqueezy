using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Orders.ValueObject;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Orders.Response;

/// <summary>
/// Represents the API response for a orders.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrdersResponse
{
    /// <summary>Gets the meta.</summary>
    [JsonPropertyName("meta")]
    public MetaPagination Meta { get; init; } = new();

    /// <summary>Gets the json api.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public DoubleLink Links { get; init; } = new();

    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<OrderResponseData> Data { get; init; } = [];
}
