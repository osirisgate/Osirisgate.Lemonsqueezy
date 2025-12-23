using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances;

/// <summary>
/// Implementation of the License Key Instances resource for managing license key instance operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyInstancesResource(LemonsqueezyClient client) : Resource(client), ILicenseKeyInstancesResource
{
    /// <inheritdoc/>
    public async Task<LicenseKeyInstanceResponse> RetrieveLicenseKeyInstanceAsync(int licenseKeyInstanceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeyInstanceResponse>(uri: $"/license-key-instances/{licenseKeyInstanceId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyInstancesResponse> ListAllLicenseKeyInstancesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeyInstancesResponse>(uri: "/license-key-instances", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<LicenseKeyResponse> RetrieveLicenseKeyAsync(int licenseKeyInstanceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeyResponse>(uri: $"/license-key-instances/{licenseKeyInstanceId}/license-key", cancellationToken: cancellationToken);
    }
}
