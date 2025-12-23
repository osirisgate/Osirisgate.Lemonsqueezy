using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Customers;

/// <summary>
/// Implementation of the Customers resource for managing customer-related operations.
/// </summary>
/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CustomersResource(ILemonsqueezyClient client) : Resource(client), ICustomersResource
{
    /// <inheritdoc/>
    public async Task<CustomerResponse> CreateCustomerAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<CustomerResponse>(uri: "/customers", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> RetrieveCustomerAsync(int customerId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CustomerResponse>(uri: $"/customers/{customerId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<CustomerResponse> UpdateCustomerAsync(int customerId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PatchAsync<CustomerResponse>(uri: $"/customers/{customerId}", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomersResponse> ListAllCustomersAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CustomersResponse>(uri: "/customers", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int customerId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/customers/{customerId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrdersRelationShipResponse> RetrieveOrdersAsync(int customerId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrdersRelationShipResponse>(uri: $"customers/{customerId}/orders", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionsRelationShipResponse> RetrieveSubscriptionsAsync(int customerId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionsRelationShipResponse>(uri: $"customers/{customerId}/subscriptions", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeysRelationShipResponse> RetrieveLicenseKeysAsync(int customerId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeysRelationShipResponse>(uri: $"customers/{customerId}/license-keys", filters: filters, cancellationToken: cancellationToken);
    }
}
