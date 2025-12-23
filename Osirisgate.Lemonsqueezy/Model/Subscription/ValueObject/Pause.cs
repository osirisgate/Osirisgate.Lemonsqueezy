using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Subscription.ValueObject;

/// <summary>
/// Represents a pause in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class Pause
{
    /// <summary>Gets the mode.</summary>
    [JsonPropertyName("mode")]
    public string Mode { get; init; } = string.Empty;

    /// <summary>Gets the resumes at.</summary>
    [JsonPropertyName("resumes_at")]
    public string ResumesAt { get; init; } = string.Empty;
}
