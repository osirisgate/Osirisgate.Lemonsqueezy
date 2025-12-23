using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.Response;

/// <summary>
/// Represents the API response for a license key instances relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyInstancesRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<LicenseKeyInstanceResponseData> Data { get; init; } = [];
}
