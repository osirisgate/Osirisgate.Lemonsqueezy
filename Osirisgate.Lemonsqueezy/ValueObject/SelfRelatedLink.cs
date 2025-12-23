using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents a self related link in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SelfRelatedLink
{
    /// <summary>Gets the self.</summary>
    [JsonPropertyName("self")]
    public string Self { get; init; } = string.Empty;

    /// <summary>Gets the related.</summary>
    [JsonPropertyName("related")]
    public string Related { get; init; } = string.Empty;
}
