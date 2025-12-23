using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.ValueObject;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;

/// <summary>
/// Represents the API response for a discount redemption.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountRedemptionResponse
{
    /// <summary>Gets the json api.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public DiscountRedemptionResponseData Data { get; init; } = new();
}
