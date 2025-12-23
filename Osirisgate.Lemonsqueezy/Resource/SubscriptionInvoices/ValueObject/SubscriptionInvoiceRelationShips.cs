using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.ValueObject;

/// <summary>
/// Represents the relationship links for a subscription invoice.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionInvoiceRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();

    /// <summary>Gets the subscription.</summary>
    [JsonPropertyName("subscription")]
    public RelationShipLink Subscription { get; init; } = new();

    /// <summary>Gets the customer.</summary>
    [JsonPropertyName("customer")]
    public RelationShipLink Customer { get; init; } = new();
}
