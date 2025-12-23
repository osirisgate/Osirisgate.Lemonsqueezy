using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;

/// <summary>
/// Represents the API response for a subscription items relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionItemsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<SubscriptionItemResponseData> Data { get; init; } = [];
}