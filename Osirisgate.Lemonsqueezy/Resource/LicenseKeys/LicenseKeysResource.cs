using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeys;

/// <summary>
/// Implementation of the License Keys resource for managing license key operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeysResource(ILemonsqueezyClient client) : Resource(client), ILicenseKeysResource
{
    /// <inheritdoc/>
    public async Task<LicenseKeyResponse> UpdateLicenseKeyAsync(int licenseKeyId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PatchAsync<LicenseKeyResponse>(uri: $"/license-keys/{licenseKeyId}", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyResponse> RetrieveLicenseKeyAsync(int licenseKeyId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeyResponse>(uri: $"/license-keys/{licenseKeyId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<LicenseKeysResponse> ListAllLicenseKeysAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeysResponse>(uri: "/license-keys", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int licenseKeyId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/license-keys/{licenseKeyId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> RetrieveCustomerAsync(int licenseKeyId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CustomerResponse>(uri: $"/license-keys/{licenseKeyId}/customer", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderResponse> RetrieveOrderAsync(int licenseKeyId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderResponse>(uri: $"/license-keys/{licenseKeyId}/order", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderItemResponse> RetrieveOrderItemAsync(int licenseKeyId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderItemResponse>(uri: $"/license-keys/{licenseKeyId}/order-item", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductResponse> RetrieveProductAsync(int licenseKeyId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductResponse>(uri: $"/license-keys/{licenseKeyId}/product", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeyInstancesRelationShipResponse> RetrieveLicenseKeyInstancesRelationshipAsync(int licenseKeyId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeyInstancesRelationShipResponse>(uri: $"license-keys/{licenseKeyId}/license-key-instances", filters: filters, cancellationToken: cancellationToken);
    }
}
