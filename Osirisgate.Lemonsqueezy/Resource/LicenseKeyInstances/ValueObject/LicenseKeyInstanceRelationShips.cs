using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.ValueObject;

/// <summary>
/// Represents the relationship links for a license key instance.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyInstanceRelationShips
{
    /// <summary>Gets the license key.</summary>
    [JsonPropertyName("license-key")]
    public RelationShipLink LicenseKey { get; init; } = new();
}
