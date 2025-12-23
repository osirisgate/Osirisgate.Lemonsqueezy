using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Checkouts.ValueObject;

/// <summary>
/// Represents the relationship links for a checkout.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CheckoutRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();

    /// <summary>Gets the variant.</summary>
    [JsonPropertyName("variant")]
    public RelationShipLink Variant { get; init; } = new();
}
