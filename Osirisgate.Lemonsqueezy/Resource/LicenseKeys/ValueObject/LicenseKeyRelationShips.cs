using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeys.ValueObject;

/// <summary>
/// Represents the relationship links for a license key.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyRelationShips
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

    /// <summary>Gets the license key instances.</summary>
    [JsonPropertyName("license-key-instances")]
    public RelationShipLink LicenseKeyInstances { get; init; } = new();
}
