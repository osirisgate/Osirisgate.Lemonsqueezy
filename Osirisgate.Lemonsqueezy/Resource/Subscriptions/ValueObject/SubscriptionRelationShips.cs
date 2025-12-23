using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Subscriptions.ValueObject;

/// <summary>
/// Represents the relationship links for a subscription.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();

    /// <summary>Gets the customer.</summary>
    [JsonPropertyName("customer")]
    public RelationShipLink Customer { get; init; } = new();

    /// <summary>Gets the order.</summary>
    [JsonPropertyName("order")]
    public RelationShipLink Order { get; init; } = new();

    /// <summary>Gets the order item.</summary>
    [JsonPropertyName("order-item")]
    public RelationShipLink OrderItem { get; init; } = new();

    /// <summary>Gets the product.</summary>
    [JsonPropertyName("product")]
    public RelationShipLink Product { get; init; } = new();

    /// <summary>Gets the variant.</summary>
    [JsonPropertyName("variant")]
    public RelationShipLink Variant { get; init; } = new();

    /// <summary>Gets the subscription items.</summary>
    [JsonPropertyName("subscription-items")]
    public RelationShipLink SubscriptionItems { get; init; } = new();

    /// <summary>Gets the subscription invoices.</summary>
    [JsonPropertyName("subscription-invoices")]
    public RelationShipLink SubscriptionInvoices { get; init; } = new();
}
