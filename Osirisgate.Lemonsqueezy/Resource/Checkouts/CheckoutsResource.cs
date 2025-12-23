using Osirisgate.Lemonsqueezy.Resource.Checkouts.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Checkouts;

/// <summary>
/// Implementation of the Checkouts resource for managing checkout-related operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CheckoutsResource(ILemonsqueezyClient client) : Resource(client), ICheckoutsResource
{
    /// <summary>
    /// Creates a new checkout session.
    /// </summary>
    /// <param name="data">The checkout data.</param>
    /// <returns>A task that represents the asynchronous operation, containing the checkout response.</returns>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<CheckoutResponse> CreateCheckoutAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<CheckoutResponse>(uri: "/checkouts", data: data, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves a specific checkout by ID.
    /// </summary>
    /// <param name="checkoutId">The ID of the checkout to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the checkout response.</returns>
    public async Task<CheckoutResponse> RetrieveCheckoutAsync(int checkoutId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CheckoutResponse>(uri: $"/checkouts/{checkoutId}", cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Lists all checkouts with optional filtering.
    /// </summary>
    /// <param name="filters">Optional filters to apply to the checkout list.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of checkouts.</returns>
    public async Task<CheckoutsResponse> ListAllCheckoutsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CheckoutsResponse>(uri: "/checkouts", filters: filters, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves the store associated with a specific checkout.
    /// </summary>
    /// <param name="checkoutId">The ID of the checkout.</param>
    /// <returns>A task that represents the asynchronous operation, containing the store response.</returns>
    public async Task<StoreResponse> RetrieveStoreAsync(int checkoutId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/checkouts/{checkoutId}/store", cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves the variant associated with a specific checkout.
    /// </summary>
    /// <param name="checkoutId">The ID of the checkout.</param>
    /// <returns>A task that represents the asynchronous operation, containing the variant response.</returns>
    public async Task<VariantResponse> RetrieveVariantAsync(int checkoutId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantResponse>(uri: $"/checkouts/{checkoutId}/variant", cancellationToken: cancellationToken);
    }
}
