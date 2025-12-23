using Osirisgate.Lemonsqueezy.Resource.Affiliates.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Users.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Affiliates;

/// <summary>
/// Implementation of the Affiliates resource for managing affiliate-related operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class AffiliatesResource(ILemonsqueezyClient client) : Resource(client), IAffiliatesResource
{
    /// <summary>
    /// Retrieves a specific affiliate by ID.
    /// </summary>
    /// <param name="affiliateId">The ID of the affiliate to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the affiliate response.</returns>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<AffiliateResponse> RetrieveAffiliateAsync(int affiliateId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<AffiliateResponse>(uri: $"/affiliates/{affiliateId}", cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Lists all affiliates with optional filtering.
    /// </summary>
    /// <param name="filters">Optional filters to apply to the affiliate list.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of affiliates.</returns>
    public async Task<AffiliatesResponse> ListAllAffiliatesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<AffiliatesResponse>(uri: "/affiliates", filters: filters, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves the store associated with a specific affiliate.
    /// </summary>
    /// <param name="affiliateId">The ID of the affiliate.</param>
    /// <returns>A task that represents the asynchronous operation, containing the store response.</returns>
    public async Task<StoreResponse> RetrieveStoreAsync(int affiliateId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/affiliates/{affiliateId}/store", cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves the user associated with a specific affiliate.
    /// </summary>
    /// <param name="affiliateId">The ID of the affiliate.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user response.</returns>
    public async Task<UserResponse> RetrieveUserAsync(int affiliateId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<UserResponse>(uri: $"/affiliates/{affiliateId}/user", cancellationToken: cancellationToken);
    }
}
