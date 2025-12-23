using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Variant;

/// <summary>
/// Represents a variant in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Variant : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public VariantAttributes Attributes { get; init; } = new();
}
