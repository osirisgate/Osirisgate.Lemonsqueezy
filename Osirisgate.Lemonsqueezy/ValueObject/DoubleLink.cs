using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents a double link in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DoubleLink
{
    /// <summary>Gets the first.</summary>
    [JsonPropertyName("first")]
    public string First { get; init; } = string.Empty;

    /// <summary>Gets the last.</summary>
    [JsonPropertyName("last")]
    public string Last { get; init; } = string.Empty;
}
