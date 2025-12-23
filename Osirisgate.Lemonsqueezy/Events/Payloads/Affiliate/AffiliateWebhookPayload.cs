using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Affiliates.ValueObject;

namespace Osirisgate.Lemonsqueezy.Events.Payloads.Affiliate;

/// <summary>
/// Represents a webhook payload for affiliate events (affiliate_activated).
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class AffiliateWebhookPayload : WebhookPayload
{
    /// <summary>Gets the affiliate data.</summary>
    [JsonPropertyName("data")]
    public AffiliateResponseData Data { get; init; } = new();
}
