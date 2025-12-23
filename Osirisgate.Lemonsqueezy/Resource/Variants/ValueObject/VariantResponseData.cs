using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Variants.ValueObject;

/// <summary>
/// Represents the API response for a variant data.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class VariantResponseData : Model.Variant.Variant
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the relation ships.</summary>
    [JsonPropertyName("relationships")]
    public VariantRelationShips RelationShips { get; init; } = new();
}
