using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;
using System.Threading;

namespace Osirisgate.Lemonsqueezy.Resource.Discounts;

/// <summary>
/// Implementation of the Discounts resource for managing discount-related operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountsResource(ILemonsqueezyClient client) : Resource(client), IDiscountsResource
{
    /// <inheritdoc/>
    public async Task<DiscountResponse> CreateDiscountAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<DiscountResponse>(uri: "/discounts", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, object>> DeleteDiscountAsync(int discountId, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync<Dictionary<string, object>>(uri: $"/discounts/{discountId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<DiscountResponse> RetrieveDiscountAsync(int discountId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountResponse>(uri: $"/discounts/{discountId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountsResponse> ListAllDiscountsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountsResponse>(uri: "/discounts", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int discountId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/discounts/{discountId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VariantsRelationShipResponse> RetrieveVariantsAsync(int discountId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantsRelationShipResponse>(uri: $"discounts/{discountId}/variants", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountRedemptionsRelationShipResponse> RetrieveDiscountRedemptionsAsync(int discountId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountRedemptionsRelationShipResponse>(uri: $"discounts/{discountId}/discount-redemptions", filters: filters, cancellationToken: cancellationToken);
    }
}
