using Osirisgate.Lemonsqueezy.Model.LicenseApi;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseApi;

/// <summary>
/// Implementation of the License API resource for managing license operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseApiResource(ILemonsqueezyClient client) : Resource(client), ILicenseApiResource
{
    /// <inheritdoc/>
    public async Task<ActivateLicenseKey> ActivateLicenseKeyAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<ActivateLicenseKey>(uri: "/licenses/activate", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DeactivateLicenseKey> DeactivateLicenseKeyAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<DeactivateLicenseKey>(uri: "/licenses/deactivate", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ValidateLicenseKey> ValidateLicenseKeyAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<ValidateLicenseKey>(uri: "/licenses/validate", data: data, cancellationToken: cancellationToken);
    }
}
