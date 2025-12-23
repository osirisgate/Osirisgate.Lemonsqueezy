using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Prices;

/// <summary>
/// Interface for managing price-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IPricesResource
{
    /// <summary>Retrieves a specific price by ID.</summary>
    public Task<PriceResponse> RetrievePriceAsync(int priceId, CancellationToken cancellationToken = default);

    /// <summary>Lists all prices with optional filtering.</summary>
    public Task<PricesResponse> ListAllPricesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the variant associated with a price.</summary>
    public Task<VariantResponse> RetrieveVariantAsync(int priceId, CancellationToken cancellationToken = default);
}
