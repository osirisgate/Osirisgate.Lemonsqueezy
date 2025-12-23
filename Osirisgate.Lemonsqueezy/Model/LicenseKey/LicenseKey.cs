using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.LicenseKey;

/// <summary>
/// Represents a license key in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class LicenseKey : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public LicenseKeyAttributes Attributes { get; init; } = new();
}
