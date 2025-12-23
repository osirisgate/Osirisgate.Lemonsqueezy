using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Variants.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Variants.Response;

/// <summary>
/// Represents the API response for a variants relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class VariantsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<VariantResponseData> Data { get; init; } = [];
}
