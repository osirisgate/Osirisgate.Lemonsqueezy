using Osirisgate.Lemonsqueezy.Resource.Checkouts.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Checkouts;

/// <summary>
/// Interface for managing checkout-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ICheckoutsResource
{
    /// <summary>
    /// Creates a new checkout session.
    /// </summary>
    /// <param name="data">The checkout data.</param>
    /// <returns>A task that represents the asynchronous operation, containing the checkout response.</returns>
    public Task<CheckoutResponse> CreateCheckoutAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific checkout by ID.
    /// </summary>
    /// <param name="checkoutId">The ID of the checkout to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, containing the checkout response.</returns>
    public Task<CheckoutResponse> RetrieveCheckoutAsync(int checkoutId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all checkouts with optional filtering.
    /// </summary>
    /// <param name="filters">Optional filters to apply to the checkout list.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of checkouts.</returns>
    public Task<CheckoutsResponse> ListAllCheckoutsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the store associated with a specific checkout.
    /// </summary>
    /// <param name="checkoutId">The ID of the checkout.</param>
    /// <returns>A task that represents the asynchronous operation, containing the store response.</returns>
    public Task<StoreResponse> RetrieveStoreAsync(int checkoutId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the variant associated with a specific checkout.
    /// </summary>
    /// <param name="checkoutId">The ID of the checkout.</param>
    /// <returns>A task that represents the asynchronous operation, containing the variant response.</returns>
    public Task<VariantResponse> RetrieveVariantAsync(int checkoutId, CancellationToken cancellationToken = default);
}
