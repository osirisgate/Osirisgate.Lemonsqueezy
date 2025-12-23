using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances;

/// <summary>
/// Interface for managing license key instance-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ILicenseKeyInstancesResource
{
    /// <summary>Retrieves a specific license key instance by ID.</summary>
    public Task<LicenseKeyInstanceResponse> RetrieveLicenseKeyInstanceAsync(int licenseKeyInstanceId, CancellationToken cancellationToken = default);

    /// <summary>Lists all license key instances with optional filtering.</summary>
    public Task<LicenseKeyInstancesResponse> ListAllLicenseKeyInstancesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the license key associated with an instance.</summary>
    public Task<LicenseKeyResponse> RetrieveLicenseKeyAsync(int licenseKeyInstanceId, CancellationToken cancellationToken = default);
}
