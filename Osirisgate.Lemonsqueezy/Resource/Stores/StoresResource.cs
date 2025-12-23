using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Stores;

/// <summary>
/// Implementation of the Stores resource for managing store operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class StoresResource(ILemonsqueezyClient client) : Resource(client), IStoresResource
{
    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int storeId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"stores/{storeId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoresResponse> ListAllStoresAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoresResponse>(uri: "stores", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<ProductsRelationShipResponse> RetrieveProductsAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductsRelationShipResponse>(uri: $"stores/{storeId}/products", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrdersRelationShipResponse> RetrieveOrdersAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrdersRelationShipResponse>(uri: $"stores/{storeId}/orders", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionsRelationShipResponse> RetrieveSubscriptionsAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionsRelationShipResponse>(uri: $"stores/{storeId}/subscriptions", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountsRelationShipResponse> RetrieveDiscountsAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountsRelationShipResponse>(uri: $"stores/{storeId}/discounts", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseKeysRelationShipResponse> RetrieveLicenseKeysAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<LicenseKeysRelationShipResponse>(uri: $"stores/{storeId}/license-keys", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhooksRelationShipResponse> RetrieveWebhooksAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<WebhooksRelationShipResponse>(uri: $"stores/{storeId}/webhooks", filters: filters, cancellationToken: cancellationToken);
    }
}
