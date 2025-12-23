using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;

namespace Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions;

/// <summary>
/// Interface for managing discount redemption-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IDiscountRedemptionsResource
{
    /// <summary>Retrieves a specific discount redemption by ID.</summary>
    public Task<DiscountRedemptionResponse> RetrieveDiscountRedemptionAsync(int discountId, CancellationToken cancellationToken = default);

    /// <summary>Lists all discount redemptions with optional filtering.</summary>
    public Task<DiscountRedemptionsResponse> ListAllDiscountRedemptionsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the discount associated with a redemption.</summary>
    public Task<DiscountResponse> RetrieveDiscountAsync(int discountId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the order associated with a discount redemption.</summary>
    public Task<OrderResponse> RetrieveOrderAsync(int discountId, CancellationToken cancellationToken = default);
}
