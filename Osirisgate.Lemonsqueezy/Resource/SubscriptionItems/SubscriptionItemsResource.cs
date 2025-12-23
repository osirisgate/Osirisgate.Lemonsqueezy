using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems;

/// <summary>
/// Implementation of the Subscription Items resource for managing subscription item operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionItemsResource(ILemonsqueezyClient client) : Resource(client), ISubscriptionItemsResource
{
    /// <inheritdoc/>
    public async Task<SubscriptionItemResponse> UpdateSubscriptionItemAsync(int subscriptionItemId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PatchAsync<SubscriptionItemResponse>(uri: $"/subscription-items/{subscriptionItemId}", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionItemResponse> RetrieveSubscriptionItemAsync(int subscriptionItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionItemResponse>(uri: $"/subscription-items/{subscriptionItemId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<ItemCurrentUsageResponse> RetrieveItemCurrentUsageAsync(int subscriptionItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<ItemCurrentUsageResponse>(uri: $"/subscription-items/{subscriptionItemId}/current-usage", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionItemsResponse> ListAllSubscriptionItemsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionItemsResponse>(uri: "/subscription-items", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionResponse> RetrieveSubscriptionAsync(int subscriptionItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionResponse>(uri: $"/subscription-items/{subscriptionItemId}/subscription", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PriceResponse> RetrievePriceAsync(int subscriptionItemId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<PriceResponse>(uri: $"/subscription-items/{subscriptionItemId}/price", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UsageRecordsRelationShipResponse> RetrieveUsageRecordsAsync(int subscriptionItemId, Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<UsageRecordsRelationShipResponse>(uri: $"subscription-items/{subscriptionItemId}/usage-records", filters: filters, cancellationToken: cancellationToken);
    }
}
