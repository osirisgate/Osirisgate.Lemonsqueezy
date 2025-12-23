using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Affiliates.ValueObject;

/// <summary>
/// Represents the API response for a affiliate data.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class AffiliateResponseData : Model.Affiliate.Affiliate
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the relation ships.</summary>
    [JsonPropertyName("relationships")]
    public AffiliateRelationShips RelationShips { get; init; } = new();
}
