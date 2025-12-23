using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Webhooks;

/// <summary>
/// Interface for managing webhook-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IWebhooksResource
{
    /// <summary>Creates a new webhook.</summary>
    public Task<WebhookResponse> CreateWebhookAsync(Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Updates an existing webhook.</summary>
    public Task<WebhookResponse> UpdateWebhookAsync(int webhookId, Dictionary<string, object> data, CancellationToken cancellationToken = default);

    /// <summary>Deletes a webhook by ID.</summary>
    public Task<Dictionary<string, object>> DeleteWebhookAsync(int webhookId, CancellationToken cancellationToken = default);

    /// <summary>Retrieves a specific webhook by ID.</summary>
    public Task<WebhookResponse> RetrieveWebhookAsync(int webhookId, CancellationToken cancellationToken = default);

    /// <summary>Lists all webhooks with optional filtering.</summary>
    public Task<WebhooksResponse> ListAllWebhooksAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the store associated with a webhook.</summary>
    public Task<StoreResponse> RetrieveStoreAsync(int webhookId, CancellationToken cancellationToken = default);
}
