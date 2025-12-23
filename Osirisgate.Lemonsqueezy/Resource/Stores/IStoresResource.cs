using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Stores;

/// <summary>
/// Interface for managing store-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IStoresResource
{
    /// <summary>Retrieves a specific store by ID.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int storeId, CancellationToken cancellationToken = default);

    /// <summary>Lists all stores with optional filtering.</summary>
    public Task<StoresResponse> ListAllStoresAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all products for a store.</summary>
    public Task<ProductsRelationShipResponse> RetrieveProductsAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all orders for a store.</summary>
    public Task<OrdersRelationShipResponse> RetrieveOrdersAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all subscriptions for a store.</summary>
    public Task<SubscriptionsRelationShipResponse> RetrieveSubscriptionsAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all discounts for a store.</summary>
    public Task<DiscountsRelationShipResponse> RetrieveDiscountsAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all license keys for a store.</summary>
    public Task<LicenseKeysRelationShipResponse> RetrieveLicenseKeysAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all webhooks for a store.</summary>
    public Task<WebhooksRelationShipResponse> RetrieveWebhooksAsync(int storeId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
