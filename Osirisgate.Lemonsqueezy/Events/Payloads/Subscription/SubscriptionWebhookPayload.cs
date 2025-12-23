using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.ValueObject;

namespace Osirisgate.Lemonsqueezy.Events.Payloads.Subscription;

/// <summary>
/// Represents a webhook payload for subscription events
/// (subscription_created, subscription_updated, subscription_cancelled, subscription_resumed, subscription_expired, subscription_paused, subscription_unpaused).
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionWebhookPayload : WebhookPayload
{
    /// <summary>Gets the subscription data.</summary>
    [JsonPropertyName("data")]
    public SubscriptionResponseData Data { get; init; } = new();
}
