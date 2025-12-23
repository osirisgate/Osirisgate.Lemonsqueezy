using Osirisgate.Lemonsqueezy.Model.LicenseApi;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseApi;

/// <summary>
/// Interface for managing license API operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ILicenseApiResource
{
    /// <summary>Activates a license key.</summary>
    public Task<ActivateLicenseKey> ActivateLicenseKeyAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Deactivates a license key.</summary>
    public Task<DeactivateLicenseKey> DeactivateLicenseKeyAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Validates a license key.</summary>
    public Task<ValidateLicenseKey> ValidateLicenseKeyAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);
}
