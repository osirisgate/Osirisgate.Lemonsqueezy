using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.ValueObject;

/// <summary>
/// Represents the API response for a license key instance data.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyInstanceResponseData : Model.LicenseKeyInstance.LicenseKeyInstance
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the relation ships.</summary>
    [JsonPropertyName("relationships")]
    public LicenseKeyInstanceRelationShips RelationShips { get; init; } = new();
}
