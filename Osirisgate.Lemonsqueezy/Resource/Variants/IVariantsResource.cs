using Osirisgate.Lemonsqueezy.Resource.Files.Response;
using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Variants;

/// <summary>
/// Interface for managing variant-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IVariantsResource
{
    /// <summary>Retrieves a specific variant by ID.</summary>
    public Task<VariantResponse> RetrieveVariantAsync(int variantId, CancellationToken cancellationToken = default);

    /// <summary>Lists all variants with optional filtering.</summary>
    public Task<VariantsResponse> ListAllVariantsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the product associated with a variant.</summary>
    public Task<ProductResponse> RetrieveProductAsync(int variantId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all files associated with a variant.</summary>
    public Task<FilesRelationShipResponse> RetrieveFilesAsync(int variantId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the price model for a variant.</summary>
    public Task<PriceResponse> RetrievePriceModelAsync(int variantId, CancellationToken cancellationToken = default);
}
