using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents JSON:API specification version information.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class JsonApi
{
    /// <summary>Gets the JSON:API specification version.</summary>
    [JsonPropertyName("version")]
    public string Version { get; init; } = string.Empty;
}
