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
/// Interface for managing subscription-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ISubscriptionsResource
{
    /// <summary>Updates an existing subscription.</summary>
    public Task<Subscription> UpdateSubscriptionAsync(int subscriptionId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Cancels a subscription.</summary>
    public Task<SubscriptionResponse> CancelSubscriptionAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific subscription by ID.</summary>
    public Task<SubscriptionResponse> RetrieveSubscriptionAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Lists all subscriptions with optional filtering.</summary>
    public Task<SubscriptionsResponse> ListAllSubscriptionsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a subscription.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the customer associated with a subscription.</summary>
    public Task<CustomerResponse> RetrieveCustomerAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the order associated with a subscription.</summary>
    public Task<OrderResponse> RetrieveOrderAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the order item associated with a subscription.</summary>
    public Task<OrderItemResponse> RetrieveOrderItemAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the product associated with a subscription.</summary>
    public Task<ProductResponse> RetrieveProductAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the variant associated with a subscription.</summary>
    public Task<VariantResponse> RetrieveVariantAsync(int subscriptionId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all subscription items for a subscription.</summary>
    public Task<SubscriptionItemsRelationShipResponse> RetrieveSubscriptionItemsAsync(int subscriptionId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all subscription invoices for a subscription.</summary>
    public Task<SubscriptionInvoicesRelationShipResponse> RetrieveSubscriptionInvoicesAsync(int subscriptionId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
