using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

namespace Osirisgate.Lemonsqueezy.Resource.UsageRecords;

/// <summary>
/// Implementation of the Usage Records resource for managing usage record operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UsageRecordsResource(ILemonsqueezyClient client) : Resource(client), IUsageRecordsResource
{
    /// <inheritdoc/>
    public async Task<UsageRecordResponse> CreateUsageRecordAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<UsageRecordResponse>(uri: "/usage-records", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UsageRecordResponse> RetrieveUsageRecordAsync(int usageRecordId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<UsageRecordResponse>(uri: $"/usage-records/{usageRecordId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UsageRecordsResponse> ListAllUsageRecordsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<UsageRecordsResponse>(uri: "/usage-records", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionItemResponse> RetrieveSubscriptionItemAsync(int usageRecordId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionItemResponse>(uri: $"/usage-records/{usageRecordId}/subscription-item", cancellationToken: cancellationToken);
    }
}
