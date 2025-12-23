using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices;

/// <summary>
/// Implementation of the Subscription Invoices resource for managing subscription invoice operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionInvoicesResource(ILemonsqueezyClient client) : Resource(client), ISubscriptionInvoicesResource
{
    /// <inheritdoc/>
    public async Task<GenerateSubscriptionInvoiceResponse> GenerateSubscriptionInvoiceAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default)
    {
        return await PostAsync<GenerateSubscriptionInvoiceResponse>(uri: $"/subscription-invoices/{subscriptionInvoiceId}/generate-invoice", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionInvoiceResponse> IssueRefundAsync(int subscriptionInvoiceId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<SubscriptionInvoiceResponse>(uri: $"/subscription-invoices/{subscriptionInvoiceId}/refund", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<SubscriptionInvoiceResponse> RetrieveSubscriptionInvoiceAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionInvoiceResponse>(uri: $"/subscription-invoices/{subscriptionInvoiceId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionInvoicesResponse> ListAllSubscriptionInvoicesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionInvoicesResponse>(uri: "/subscription-invoices", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/subscription-invoices/{subscriptionInvoiceId}/store", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionResponse> RetrieveSubscriptionAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<SubscriptionResponse>(uri: $"/subscription-invoices/{subscriptionInvoiceId}/subscription", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> RetrieveCustomerAsync(int subscriptionInvoiceId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<CustomerResponse>(uri: $"/subscription-invoices/{subscriptionInvoiceId}/customer", cancellationToken: cancellationToken);
    }
}
