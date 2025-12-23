using Osirisgate.Lemonsqueezy.Model.Subscription;
using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Subscriptions;

/// <summary>
/// Implementation of the Subscriptions resource for managing subscription operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionsResource(ILemonsqueezyClient client) : Resource(client), ISubscriptionsResource
{
    /// <inheritdoc/>
    public async Task<Subscription> UpdateSubscriptionAsync(int subscriptionId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PatchAsync<Subscription>(uri: $"/subscriptions/{subscriptionId}", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionResponse> CancelSubscriptionAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync<SubscriptionResponse>(uri: $"/subscriptions/{subscriptionId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<SubscriptionResponse> RetrieveSubscriptionAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionResponse>(uri: $"/subscriptions/{subscriptionId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionsResponse> ListAllSubscriptionsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionsResponse>(uri: "/subscriptions", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/subscriptions/{subscriptionId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> RetrieveCustomerAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CustomerResponse>(uri: $"/subscriptions/{subscriptionId}/customer", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderResponse> RetrieveOrderAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderResponse>(uri: $"/subscriptions/{subscriptionId}/order", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderItemResponse> RetrieveOrderItemAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderItemResponse>(uri: $"/subscriptions/{subscriptionId}/order-item", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductResponse> RetrieveProductAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductResponse>(uri: $"/subscriptions/{subscriptionId}/product", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VariantResponse> RetrieveVariantAsync(int subscriptionId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantResponse>(uri: $"/subscriptions/{subscriptionId}/variant", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionItemsRelationShipResponse> RetrieveSubscriptionItemsAsync(int subscriptionId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionItemsRelationShipResponse>(uri: $"subscriptions/{subscriptionId}/subscription-items", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionInvoicesRelationShipResponse> RetrieveSubscriptionInvoicesAsync(int subscriptionId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionInvoicesRelationShipResponse>(uri: $"subscriptions/{subscriptionId}/subscription-invoices", filters: filters, cancellationToken: cancellationToken);
    }
}
