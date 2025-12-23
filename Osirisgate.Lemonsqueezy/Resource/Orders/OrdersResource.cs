using Osirisgate.Lemonsqueezy.Model.Order;
using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Orders;

/// <summary>
/// Implementation of the Orders resource for managing order operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrdersResource(ILemonsqueezyClient client) : Resource(client), IOrdersResource
{
    /// <inheritdoc/>
    public async Task<OrderResponse> RetrieveOrderAsync(int orderId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderResponse>(uri: $"/orders/{orderId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrdersResponse> ListAllOrdersAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrdersResponse>(uri: "/orders", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<OrderInvoiceResponse> GenerateOrderInvoiceAsync(int orderId, CancellationToken cancellationToken = default)
    {
        return await PostAsync<OrderInvoiceResponse>(uri: $"/orders/{orderId}/generate-invoice", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Order> IssueRefundAsync(int orderId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<Order>(uri: $"/orders/{orderId}/refund", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int orderId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/orders/{orderId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> RetrieveCustomerAsync(int orderId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CustomerResponse>(uri: $"/orders/{orderId}/customer", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderItemsRelationShipResponse> RetrieveOrderItemsAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderItemsRelationShipResponse>(uri: $"orders/{orderId}/order-items", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionsRelationShipResponse> RetrieveSubscriptionsAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionsRelationShipResponse>(uri: $"orders/{orderId}/subscriptions", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeysRelationShipResponse> RetrieveLicenseKeysAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeysRelationShipResponse>(uri: $"orders/{orderId}/license-keys", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountRedemptionsRelationShipResponse> RetrieveDiscountRedemptionsAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountRedemptionsRelationShipResponse>(uri: $"orders/{orderId}/discount-redemptions", filters: filters, cancellationToken: cancellationToken);
    }
}
