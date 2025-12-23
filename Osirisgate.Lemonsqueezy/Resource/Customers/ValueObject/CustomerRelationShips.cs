using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Customers.ValueObject;

/// <summary>
/// Represents the relationship links for a customer.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CustomerRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();

    /// <summary>Gets the orders.</summary>
    [JsonPropertyName("orders")]
    public RelationShipLink Orders { get; init; } = new();

    /// <summary>Gets the subscriptions.</summary>
    [JsonPropertyName("subscriptions")]
    public RelationShipLink Subscriptions { get; init; } = new();

    /// <summary>Gets the license keys.</summary>
    [JsonPropertyName("license-keys")]
    public RelationShipLink LicenseKeys { get; init; } = new();
}
