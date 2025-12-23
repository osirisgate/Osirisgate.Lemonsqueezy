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
/// Interface for managing order-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IOrdersResource
{
    /// <summary>Retrieves a specific order by ID.</summary>
    public Task<OrderResponse> RetrieveOrderAsync(int orderId, CancellationToken cancellationToken = default);

    /// <summary>Lists all orders with optional filtering.</summary>
    public Task<OrdersResponse> ListAllOrdersAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Generates an invoice for an order.</summary>
    public Task<OrderInvoiceResponse> GenerateOrderInvoiceAsync(int orderId, CancellationToken cancellationToken = default);

    /// <summary>Issues a refund for an order.</summary>
    public Task<Order> IssueRefundAsync(int orderId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with an order.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int orderId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the customer associated with an order.</summary>
    public Task<CustomerResponse> RetrieveCustomerAsync(int orderId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all order items for an order.</summary>
    public Task<OrderItemsRelationShipResponse> RetrieveOrderItemsAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all subscriptions associated with an order.</summary>
    public Task<SubscriptionsRelationShipResponse> RetrieveSubscriptionsAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all license keys associated with an order.</summary>
    public Task<LicenseKeysRelationShipResponse> RetrieveLicenseKeysAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all discount redemptions for an order.</summary>
    public Task<DiscountRedemptionsRelationShipResponse> RetrieveDiscountRedemptionsAsync(int orderId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
