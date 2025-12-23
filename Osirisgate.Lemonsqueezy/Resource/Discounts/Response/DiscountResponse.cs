using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Discounts.ValueObject;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Discounts.Response;

/// <summary>
/// Represents the API response for a discount.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountResponse
{
    /// <summary>Gets the json api.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public DiscountResponseData Data { get; init; } = new();
}
