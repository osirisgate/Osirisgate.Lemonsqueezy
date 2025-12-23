using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.LicenseApi.ValueObject;

/// <summary>
/// Represents a license key in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKey
{
    /// <summary>Gets the id.</summary>
    [JsonPropertyName("id")]
    public int Id { get; init; } = default;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the key.</summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = string.Empty;

    /// <summary>Gets the activation limit.</summary>
    [JsonPropertyName("activation_limit")]
    public int ActivationLimit { get; init; } = default;

    /// <summary>Gets the activation usage.</summary>
    [JsonPropertyName("activation_usage")]
    public int ActivationUsage { get; init; } = default;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the expires at.</summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; init; } = null;
}
