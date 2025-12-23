using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices;

/// <summary>
/// Interface for managing subscription invoice-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ISubscriptionInvoicesResource
{
    /// <summary>Generates a new subscription invoice.</summary>
    public Task<GenerateSubscriptionInvoiceResponse> GenerateSubscriptionInvoiceAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default);

    /// <summary>Issues a refund for a subscription invoice.</summary>
    public Task<SubscriptionInvoiceResponse> IssueRefundAsync(int subscriptionInvoiceId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific subscription invoice by ID.</summary>
    public Task<SubscriptionInvoiceResponse> RetrieveSubscriptionInvoiceAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default);

    /// <summary>Lists all subscription invoices with optional filtering.</summary>
    public Task<SubscriptionInvoicesResponse> ListAllSubscriptionInvoicesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a subscription invoice.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the subscription associated with an invoice.</summary>
    public Task<SubscriptionResponse> RetrieveSubscriptionAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the customer associated with a subscription invoice.</summary>
    public Task<CustomerResponse> RetrieveCustomerAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default);
}
