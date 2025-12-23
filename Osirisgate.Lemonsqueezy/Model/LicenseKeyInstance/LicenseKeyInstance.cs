using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.LicenseKeyInstance;

/// <summary>
/// Represents a license key instance in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class LicenseKeyInstance : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public LicenseKeyInstanceAttributes Attributes { get; init; } = new();
}
