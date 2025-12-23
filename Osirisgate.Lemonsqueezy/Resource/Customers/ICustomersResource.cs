using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Customers;

/// <summary>
/// Interface for managing customer-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ICustomersResource
{
    /// <summary>Creates a new customer.</summary>
    public Task<CustomerResponse> CreateCustomerAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific customer by ID.</summary>
    public Task<CustomerResponse> RetrieveCustomerAsync(int customerId, CancellationToken cancellationToken = default);

    /// <summary>Updates an existing customer.</summary>
    public Task<CustomerResponse> UpdateCustomerAsync(int customerId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Lists all customers with optional filtering.</summary>
    public Task<CustomersResponse> ListAllCustomersAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a customer.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int customerId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all orders for a customer.</summary>
    public Task<OrdersRelationShipResponse> RetrieveOrdersAsync(int customerId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all subscriptions for a customer.</summary>
    public Task<SubscriptionsRelationShipResponse> RetrieveSubscriptionsAsync(int customerId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all license keys for a customer.</summary>
    public Task<LicenseKeysRelationShipResponse> RetrieveLicenseKeysAsync(int customerId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
