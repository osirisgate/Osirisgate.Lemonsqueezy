using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Prices.ValueObject;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Prices.Response;

/// <summary>
/// Represents the API response for a prices.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class PricesResponse
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
    public List<PriceResponseData> Data { get; init; } = [];
}
