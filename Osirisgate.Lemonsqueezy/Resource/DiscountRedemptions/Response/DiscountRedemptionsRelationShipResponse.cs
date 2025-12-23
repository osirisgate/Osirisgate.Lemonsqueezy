using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;

/// <summary>
/// Represents the API response for a discount redemptions relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountRedemptionsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<DiscountRedemptionResponseData> Data { get; init; } = [];
}
