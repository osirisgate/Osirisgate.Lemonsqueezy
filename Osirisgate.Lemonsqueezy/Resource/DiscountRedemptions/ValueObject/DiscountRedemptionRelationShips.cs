using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.ValueObject;

/// <summary>
/// Represents the relationship links for a discount redemption.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountRedemptionRelationShips
{
    /// <summary>Gets the discount.</summary>
    [JsonPropertyName("discount")]
    public RelationShipLink Discount { get; init; } = new();

    /// <summary>Gets the order.</summary>
    [JsonPropertyName("order")]
    public RelationShipLink Order { get; init; } = new();
}
