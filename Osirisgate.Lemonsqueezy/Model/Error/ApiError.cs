using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Error;

/// <summary>
/// Represents a single error in a JSON:API error response.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ApiError
{
    /// <summary>Gets the detailed error message.</summary>
    [JsonPropertyName("detail")]
    public string? Detail { get; init; } = null;

    /// <summary>Gets the HTTP status code as a string.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; } = null;

    /// <summary>Gets the error title.</summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; } = null;
}
