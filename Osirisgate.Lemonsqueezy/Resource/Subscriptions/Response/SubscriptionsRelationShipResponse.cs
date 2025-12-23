using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

/// <summary>
/// Represents the API response for a subscriptions relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<SubscriptionResponseData> Data { get; init; } = [];
}
