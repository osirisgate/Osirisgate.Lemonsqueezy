using Osirisgate.Lemonsqueezy.Resource.Affiliates.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Users.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Affiliates;

/// <summary>
/// Interface for managing affiliate-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IAffiliatesResource
{
    /// <summary>
    /// Retrieves a specific affiliate by ID.
    /// </summary>
    /// <param name="affiliateId">The ID of the affiliate to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the affiliate response.</returns>
    public Task<AffiliateResponse> RetrieveAffiliateAsync(int affiliateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all affiliates with optional filtering.
    /// </summary>
    /// <param name="filters">Optional filters to apply to the affiliate list.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of affiliates.</returns>
    public Task<AffiliatesResponse> ListAllAffiliatesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the store associated with a specific affiliate.
    /// </summary>
    /// <param name="affiliateId">The ID of the affiliate.</param>
    /// <returns>A task that represents the asynchronous operation, containing the store response.</returns>
    public Task<StoreResponse> RetrieveStoreAsync(int affiliateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the user associated with a specific affiliate.
    /// </summary>
    /// <param name="affiliateId">The ID of the affiliate.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user response.</returns>
    public Task<UserResponse> RetrieveUserAsync(int affiliateId, CancellationToken cancellationToken = default);
}
