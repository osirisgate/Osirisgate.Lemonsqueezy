using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.UsageRecords.ValueObject;

/// <summary>
/// Represents the relationship links for a usage record.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UsageRecordRelationShips
{
    /// <summary>Gets the subscription item.</summary>
    [JsonPropertyName("subscription-item")]
    public RelationShipLink SubscriptionItem { get; init; } = new();
}
