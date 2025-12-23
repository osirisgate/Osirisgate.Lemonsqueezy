using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.OrderItem;

/// <summary>
/// Implementation of the Order Items resource for managing order item operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public class OrderItemsResource(ILemonsqueezyClient client) : Resource(client), IOrderItemsResource
{
    /// <inheritdoc/>
    public async Task<OrderItemResponse> RetrieveOrderItemAsync(int orderItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderItemResponse>(uri: $"/order-items/{orderItemId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderItemsResponse> ListAllOrderItemsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderItemsResponse>(uri: "/order-items", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<OrderResponse> RetrieveOrderAsync(int orderItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderResponse>(uri: $"order-items/{orderItemId}/order", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductResponse> RetrieveProductAsync(int orderItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductResponse>(uri: $"order-items/{orderItemId}/product", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VariantResponse> RetrieveVariantAsync(int orderItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantResponse>(uri: $"order-items/{orderItemId}/variant", cancellationToken: cancellationToken);
    }
}
