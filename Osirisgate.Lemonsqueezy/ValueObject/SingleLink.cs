using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents a single link in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SingleLink
{
    /// <summary>Gets the self.</summary>
    [JsonPropertyName("self")]
    public string Self { get; init; } = string.Empty;
}
