using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.ValueObject;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;

/// <summary>
/// Represents the API response for a item current usage.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ItemCurrentUsageResponse
{
    /// <summary>Gets the json api.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the meta.</summary>
    [JsonPropertyName("meta")]
    public MetaItemCurrentUsage Meta { get; init; } = new();
}
