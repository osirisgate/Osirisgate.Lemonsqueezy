using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;

/// <summary>
/// Represents the API response for a license keys relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeysRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<LicenseKeyResponseData> Data { get; init; } = [];
}
