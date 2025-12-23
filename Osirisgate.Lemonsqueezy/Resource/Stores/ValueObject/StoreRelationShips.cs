using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Stores.ValueObject;

/// <summary>
/// Represents the relationship links for a store.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class StoreRelationShips
{
    /// <summary>Gets the products.</summary>
    [JsonPropertyName("products")]
    public RelationShipLink Products { get; init; } = new();

    /// <summary>Gets the orders.</summary>
    [JsonPropertyName("orders")]
    public RelationShipLink Orders { get; init; } = new();

    /// <summary>Gets the subscriptions.</summary>
    [JsonPropertyName("subscriptions")]
    public RelationShipLink Subscriptions { get; init; } = new();

    /// <summary>Gets the discounts.</summary>
    [JsonPropertyName("discounts")]
    public RelationShipLink Discounts { get; init; } = new();

    /// <summary>Gets the license keys.</summary>
    [JsonPropertyName("license-keys")]
    public RelationShipLink LicenseKeys { get; init; } = new();

    /// <summary>Gets the webhooks.</summary>
    [JsonPropertyName("webhooks")]
    public RelationShipLink Webhooks { get; init; } = new();
}
