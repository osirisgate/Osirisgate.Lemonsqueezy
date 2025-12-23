using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.OrderItem;

/// <summary>
/// Interface for managing order item-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IOrderItemsResource
{
    /// <summary>Retrieves a specific order item by ID.</summary>
    public Task<OrderItemResponse> RetrieveOrderItemAsync(int orderItemId, CancellationToken cancellationToken = default);

    /// <summary>Lists all order items with optional filtering.</summary>
    public Task<OrderItemsResponse> ListAllOrderItemsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the order associated with an order item.</summary>
    public Task<OrderResponse> RetrieveOrderAsync(int orderItemId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the product associated with an order item.</summary>
    public Task<ProductResponse> RetrieveProductAsync(int orderItemId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the variant associated with an order item.</summary>
    public Task<VariantResponse> RetrieveVariantAsync(int orderItemId, CancellationToken cancellationToken = default);
}
