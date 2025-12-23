using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Orders.ValueObject;

/// <summary>
/// Represents the relationship links for a order.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();

    /// <summary>Gets the customer.</summary>
    [JsonPropertyName("customer")]
    public RelationShipLink Customer { get; init; } = new();

    /// <summary>Gets the order items.</summary>
    [JsonPropertyName("order-items")]
    public RelationShipLink OrderItems { get; init; } = new();

    /// <summary>Gets the subscriptions.</summary>
    [JsonPropertyName("subscriptions")]
    public RelationShipLink Subscriptions { get; init; } = new();

    /// <summary>Gets the license keys.</summary>
    [JsonPropertyName("license-keys")]
    public RelationShipLink LicenseKeys { get; init; } = new();

    /// <summary>Gets the discount redemptions.</summary>
    [JsonPropertyName("discount-redemptions")]
    public RelationShipLink DiscountRedemptions { get; init; } = new();
}
