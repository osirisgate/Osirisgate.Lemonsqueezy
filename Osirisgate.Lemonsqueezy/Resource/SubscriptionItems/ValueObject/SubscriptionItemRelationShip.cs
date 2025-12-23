using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.ValueObject;

/// <summary>
/// Represents a subscription item relation ship in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionItemRelationShip
{
    /// <summary>Gets the subscription.</summary>
    [JsonPropertyName("subscription")]
    public RelationShipLink Subscription { get; init; } = new();

    /// <summary>Gets the price.</summary>
    [JsonPropertyName("price")]
    public RelationShipLink Price { get; init; } = new();

    /// <summary>Gets the usage records.</summary>
    [JsonPropertyName("usage-records")]
    public RelationShipLink UsageRecords { get; init; } = new();
}
