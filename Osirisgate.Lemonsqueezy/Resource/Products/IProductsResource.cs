using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Products;

/// <summary>
/// Interface for managing product-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IProductsResource
{
    /// <summary>Retrieves a specific product by ID.</summary>
    public Task<ProductResponse> RetrieveProductAsync(int productId, CancellationToken cancellationToken = default);

    /// <summary>Lists all products with optional filtering.</summary>
    public Task<ProductsResponse> ListAllProductsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a product.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int productId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all variants for a product.</summary>
    public Task<VariantsRelationShipResponse> RetrieveVariantsAsync(int productId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
