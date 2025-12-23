using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Webhooks;

/// <summary>
/// Implementation of the Webhooks resource for managing webhook operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class WebhooksResource(ILemonsqueezyClient client) : Resource(client), IWebhooksResource
{
    /// <inheritdoc/>
    public async Task<WebhookResponse> CreateWebhookAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PostAsync<WebhookResponse>(uri: "/webhooks", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookResponse> UpdateWebhookAsync(int webhookId, Dictionary<string, object> data, CancellationToken cancellationToken = default)
    {
        return await PatchAsync<WebhookResponse>(uri: $"/webhooks/{webhookId}", data: data, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    public async Task<Dictionary<string, object>> DeleteWebhookAsync(int webhookId, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync<Dictionary<string, object>>(uri: $"/webhooks/{webhookId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookResponse> RetrieveWebhookAsync(int webhookId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<WebhookResponse>(uri: $"/webhooks/{webhookId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhooksResponse> ListAllWebhooksAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<WebhooksResponse>(uri: "/webhooks", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StoreResponse> RetrieveStoreAsync(int webhookId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<StoreResponse>(uri: $"/webhooks/{webhookId}/store", cancellationToken: cancellationToken);
    }
}
