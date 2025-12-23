using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.File;

/// <summary>
/// Represents a file in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class File : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public FileAttributes Attributes { get; init; } = new();
}
