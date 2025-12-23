using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

namespace Osirisgate.Lemonsqueezy.Resource.UsageRecords;

/// <summary>
/// Interface for managing usage record-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IUsageRecordsResource
{
    /// <summary>Creates a new usage record.</summary>
    public Task<UsageRecordResponse> CreateUsageRecordAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific usage record by ID.</summary>
    public Task<UsageRecordResponse> RetrieveUsageRecordAsync(int usageRecordId, CancellationToken cancellationToken = default);

    /// <summary>Lists all usage records with optional filtering.</summary>
    public Task<UsageRecordsResponse> ListAllUsageRecordsAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the subscription item associated with a usage record.</summary>
    public Task<SubscriptionItemResponse> RetrieveSubscriptionItemAsync(int usageRecordId, CancellationToken cancellationToken = default);
}
