using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;

namespace Osirisgate.Lemonsqueezy.Resource.LicenseKeys;

/// <summary>
/// Interface for managing license key-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ILicenseKeysResource
{
    /// <summary>Updates an existing license key.</summary>
    public Task<LicenseKeyResponse> UpdateLicenseKeyAsync(int licenseKeyId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific license key by ID.</summary>
    public Task<LicenseKeyResponse> RetrieveLicenseKeyAsync(int licenseKeyId, CancellationToken cancellationToken = default);

    /// <summary>Lists all license keys with optional filtering.</summary>
    public Task<LicenseKeysResponse> ListAllLicenseKeysAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a license key.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int licenseKeyId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the customer associated with a license key.</summary>
    public Task<CustomerResponse> RetrieveCustomerAsync(int licenseKeyId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the order associated with a license key.</summary>
    public Task<OrderResponse> RetrieveOrderAsync(int licenseKeyId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the order item associated with a license key.</summary>
    public Task<OrderItemResponse> RetrieveOrderItemAsync(int licenseKeyId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the product associated with a license key.</summary>
    public Task<ProductResponse> RetrieveProductAsync(int licenseKeyId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all license key instances for a license key.</summary>
    public Task<LicenseKeyInstancesRelationShipResponse> RetrieveLicenseKeyInstancesRelationshipAsync(int licenseKeyId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
