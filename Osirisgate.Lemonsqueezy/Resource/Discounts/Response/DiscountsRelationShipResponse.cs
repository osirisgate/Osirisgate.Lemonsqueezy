using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Discounts.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Discounts.Response;

/// <summary>
/// Represents the API response for a discounts relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<DiscountResponseData> Data { get; init; } = [];
}
