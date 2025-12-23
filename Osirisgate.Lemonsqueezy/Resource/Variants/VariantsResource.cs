using Osirisgate.Lemonsqueezy.Resource.Files.Response;
using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Variants;

/// <summary>
/// Implementation of the Variants resource for managing variant operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class VariantsResource(ILemonsqueezyClient client) : Resource(client), IVariantsResource
{
    /// <inheritdoc/>
    public async Task<VariantResponse> RetrieveVariantAsync(int variantId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantResponse>(uri: $"/variants/{variantId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VariantsResponse> ListAllVariantsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantsResponse>(uri: "/variants", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<ProductResponse> RetrieveProductAsync(int variantId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ProductResponse>(uri: $"/variants/{variantId}/product", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FilesRelationShipResponse> RetrieveFilesAsync(int variantId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<FilesRelationShipResponse>(uri: $"variants/{variantId}/files", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PriceResponse> RetrievePriceModelAsync(int variantId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<PriceResponse>(uri: $"/variants/{variantId}/price-model", cancellationToken: cancellationToken);
    }
}
