using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Error;

/// <summary>
/// Represents an error response from the Lemonsqueezy API following JSON:API specification.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ErrorResponse
{
    /// <summary>Gets the JSON:API version information.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the list of errors.</summary>
    [JsonPropertyName("errors")]
    public List<ApiError> Errors { get; init; } = [];
}
