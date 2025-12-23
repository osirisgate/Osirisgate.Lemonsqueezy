using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model;

/// <summary>
/// Abstract base class for all Lemonsqueezy API model entities.
/// Provides common properties for ID and type identification.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Model
{
    /// <summary>Gets the unique identifier of the entity.</summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    /// <summary>Gets the type of the entity.</summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
}
