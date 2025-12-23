using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents metadata for paginated API responses.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class MetaPagination
{
    /// <summary>Gets the pagination information.</summary>
    [JsonPropertyName("page")]
    public Page Page { get; init; } = new();
}
