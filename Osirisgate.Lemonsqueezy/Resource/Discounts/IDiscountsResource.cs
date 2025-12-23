using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Discounts;

/// <summary>
/// Interface for managing discount-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IDiscountsResource
{
    /// <summary>Creates a new discount.</summary>
    public Task<DiscountResponse> CreateDiscountAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Deletes a discount by ID.</summary>
    public Task<Dictionary<string, object>> DeleteDiscountAsync(int discountId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific discount by ID.</summary>
    public Task<DiscountResponse> RetrieveDiscountAsync(int discountId, CancellationToken cancellationToken = default);

    /// <summary>Lists all discounts with optional filtering.</summary>
    public Task<DiscountsResponse> ListAllDiscountsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a discount.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int discountId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all variants associated with a discount.</summary>
    public Task<VariantsRelationShipResponse> RetrieveVariantsAsync(int discountId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all redemptions for a discount.</summary>
    public Task<DiscountRedemptionsRelationShipResponse> RetrieveDiscountRedemptionsAsync(int discountId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
