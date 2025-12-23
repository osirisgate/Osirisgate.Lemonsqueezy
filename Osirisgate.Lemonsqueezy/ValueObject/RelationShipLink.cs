using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents a relation ship link in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class RelationShipLink
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SelfRelatedLink Links { get; init; } = new();
}
