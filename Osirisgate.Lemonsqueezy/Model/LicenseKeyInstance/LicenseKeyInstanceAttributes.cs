using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.LicenseKeyInstance;

/// <summary>
/// Represents the attributes of a license key instance.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyInstanceAttributes
{
    /// <summary>Gets the license key id.</summary>
    [JsonPropertyName("license_key_id")]
    public int LicenseKeyId { get; init; } = default;

    /// <summary>Gets the identifier.</summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; } = string.Empty;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
