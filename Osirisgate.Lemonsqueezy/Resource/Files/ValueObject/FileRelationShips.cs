using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Files.ValueObject;

/// <summary>
/// Represents the relationship links for a file.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class FileRelationShips
{
    /// <summary>Gets the variant.</summary>
    [JsonPropertyName("variant")]
    public RelationShipLink Variant { get; init; } = new();
}
