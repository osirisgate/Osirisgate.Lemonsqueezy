using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Prices;

/// <summary>
/// Implementation of the Prices resource for managing price operations.
/// </summary>
/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class PricesResource(ILemonsqueezyClient client) : Resource(client), IPricesResource
{
    /// <inheritdoc/>
    public async Task<PriceResponse> RetrievePriceAsync(int priceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<PriceResponse>(uri: $"/prices/{priceId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PricesResponse> ListAllPricesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<PricesResponse>(uri: "/prices", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<VariantResponse> RetrieveVariantAsync(int priceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantResponse>(uri: $"/prices/{priceId}/variant", cancellationToken: cancellationToken);
    }
}
