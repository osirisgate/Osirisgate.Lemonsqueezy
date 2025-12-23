using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.LicenseApi.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.LicenseApi;

/// <summary>
/// Represents a validate license key in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ValidateLicenseKey
{
    /// <summary>Gets the valid.</summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; init; } = false;

    /// <summary>Gets the error.</summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; } = null;

    /// <summary>Gets the license key.</summary>
    [JsonPropertyName("license_key")]
    public ValueObject.LicenseKey LicenseKey { get; init; } = new();

    /// <summary>Gets the instance.</summary>
    [JsonPropertyName("instance")]
    public Instance? Instance { get; init; } = null;

    /// <summary>Gets the meta.</summary>
    [JsonPropertyName("meta")]
    public Meta Meta { get; init; } = new();
}
