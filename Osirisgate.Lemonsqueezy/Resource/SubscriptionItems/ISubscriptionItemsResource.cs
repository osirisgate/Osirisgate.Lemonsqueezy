using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems;

/// <summary>
/// Interface for managing subscription item-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ISubscriptionItemsResource
{
    /// <summary>Updates an existing subscription item.</summary>
    public Task<SubscriptionItemResponse> UpdateSubscriptionItemAsync(int subscriptionItemId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific subscription item by ID.</summary>
    public Task<SubscriptionItemResponse> RetrieveSubscriptionItemAsync(int subscriptionItemId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the current usage for a subscription item.</summary>
    public Task<ItemCurrentUsageResponse> RetrieveItemCurrentUsageAsync(int subscriptionItemId, CancellationToken cancellationToken = default);

    /// <summary>Lists all subscription items with optional filtering.</summary>
    public Task<SubscriptionItemsResponse> ListAllSubscriptionItemsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the subscription associated with a subscription item.</summary>
    public Task<SubscriptionResponse> RetrieveSubscriptionAsync(int subscriptionItemId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the price associated with a subscription item.</summary>
    public Task<PriceResponse> RetrievePriceAsync(int subscriptionItemId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves all usage records for a subscription item.</summary>
    public Task<UsageRecordsRelationShipResponse> RetrieveUsageRecordsAsync(int subscriptionItemId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);
}
