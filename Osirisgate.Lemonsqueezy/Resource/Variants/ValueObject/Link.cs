using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Resource.Variants.ValueObject;

/// <summary>
/// Represents a link in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class Link
{
    /// <summary>Gets the title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    /// <summary>Gets the url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;
}
