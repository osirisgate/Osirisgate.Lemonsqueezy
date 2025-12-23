using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Products;

/// <summary>
/// Implementation of the Products resource for managing product operations.
/// </summary>
/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ProductsResource(ILemonsqueezyClient client) : Resource(client), IProductsResource
{
    /// <inheritdoc/>
    public async Task<ProductResponse> RetrieveProductAsync(int productId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductResponse>(uri: $"/products/{productId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductsResponse> ListAllProductsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductsResponse>(uri: "/products", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<StoreResponse> RetrieveStoreAsync(int productId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/products/{productId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VariantsRelationShipResponse> RetrieveVariantsAsync(int productId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantsRelationShipResponse>(uri: $"products/{productId}/variants", filters: filters, cancellationToken: cancellationToken);
    }
}
