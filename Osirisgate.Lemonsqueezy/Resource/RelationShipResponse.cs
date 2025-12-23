using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource;

/// <summary>
/// Abstract base class for relationship API responses following JSON:API specification.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class RelationShipResponse
{
    /// <summary>Gets the metadata including pagination information.</summary>
    [JsonPropertyName("meta")]
    public MetaPagination Meta { get; init; } = new();

    /// <summary>Gets the JSON:API version information.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the hypermedia links for navigation.</summary>
    [JsonPropertyName("links")]
    public RelationShipLinks Links { get; init; } = new();
}
