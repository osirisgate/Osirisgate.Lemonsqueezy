using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.ValueObject;

namespace Osirisgate.Lemonsqueezy.Events.Payloads.Subscription;

/// <summary>
/// Represents a webhook payload for subscription payment events
/// (subscription_payment_success, subscription_payment_failed, subscription_payment_recovered, subscription_payment_refunded).
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionPaymentWebhookPayload : WebhookPayload
{
    /// <summary>Gets the subscription invoice data.</summary>
    [JsonPropertyName("data")]
    public SubscriptionInvoiceResponseData Data { get; init; } = new();
}
