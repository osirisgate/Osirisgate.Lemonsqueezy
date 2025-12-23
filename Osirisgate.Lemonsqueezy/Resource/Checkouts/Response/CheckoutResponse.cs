using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Checkouts.ValueObject;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Checkouts.Response;

/// <summary>
/// Represents the API response for a checkout.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CheckoutResponse
{
    /// <summary>Gets the json api.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public CheckoutResponseData Data { get; init; } = new();
}
