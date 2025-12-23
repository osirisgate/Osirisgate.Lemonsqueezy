using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;

namespace Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions;

/// <summary>
/// Implementation of the Discount Redemptions resource for managing discount redemption-related operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DiscountRedemptionsResource(ILemonsqueezyClient client) : Resource(client), IDiscountRedemptionsResource
{
    /// <inheritdoc/>
    public async Task<DiscountRedemptionResponse> RetrieveDiscountRedemptionAsync(int discountId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountRedemptionResponse>(uri: $"/discount-redemptions/{discountId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DiscountRedemptionsResponse> ListAllDiscountRedemptionsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountRedemptionsResponse>(uri: "/discount-redemptions", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<DiscountResponse> RetrieveDiscountAsync(int discountId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<DiscountResponse>(uri: $"/discount-redemptions/{discountId}/discount", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OrderResponse> RetrieveOrderAsync(int discountId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<OrderResponse>(uri: $"/discount-redemptions/{discountId}/order", cancellationToken: cancellationToken);
    }
}
