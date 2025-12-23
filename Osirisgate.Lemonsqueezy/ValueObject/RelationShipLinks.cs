using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents hypermedia links for resource relationships.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class RelationShipLinks
{
    /// <summary>Gets the link to the first page.</summary>
    [JsonPropertyName("first")]
    public string First { get; init; } = string.Empty;

    /// <summary>Gets the link to the last page.</summary>
    [JsonPropertyName("last")]
    public string Last { get; init; } = string.Empty;

    /// <summary>Gets the link to the next page.</summary>
    [JsonPropertyName("next")]
    public string Next { get; init; } = string.Empty;

    /// <summary>Gets the link to the related resource.</summary>
    [JsonPropertyName("related")]
    public string Related { get; init; } = string.Empty;

    /// <summary>Gets the link to the current resource.</summary>
    [JsonPropertyName("self")]
    public string Self { get; init; } = string.Empty;
}
