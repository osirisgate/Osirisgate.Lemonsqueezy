using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.LicenseApi.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.LicenseApi;

/// <summary>
/// Represents a deactivate license key in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DeactivateLicenseKey
{
    /// <summary>Gets the de activated.</summary>
    [JsonPropertyName("deactivated")]
    public bool DeActivated { get; init; } = false;

    /// <summary>Gets the error.</summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; } = null;

    [JsonPropertyName("license_key")]
    public ValueObject.LicenseKey LicenseKey { get; init; } = new();

    /// <summary>Gets the meta.</summary>
    [JsonPropertyName("meta")]
    public Meta Meta { get; init; } = new();
}
