using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Orders.ValueObject;

namespace Osirisgate.Lemonsqueezy.Events.Payloads.Order;

/// <summary>
/// Represents a webhook payload for order events (order_created, order_refunded).
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderWebhookPayload : WebhookPayload
{
    /// <summary>Gets the order data.</summary>
    [JsonPropertyName("data")]
    public OrderResponseData Data { get; init; } = new();
}
