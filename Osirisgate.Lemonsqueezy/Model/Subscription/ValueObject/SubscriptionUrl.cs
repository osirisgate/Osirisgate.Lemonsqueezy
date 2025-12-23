using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Subscription.ValueObject;

/// <summary>
/// Represents a subscription url in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionUrl
{
    /// <summary>Gets the update payment method.</summary>
    [JsonPropertyName("update_payment_method")]
    public string UpdatePaymentMethod { get; init; } = string.Empty;

    /// <summary>Gets the customer portal.</summary>
    [JsonPropertyName("customer_portal")]
    public string CustomerPortal { get; init; } = string.Empty;

    /// <summary>Gets the customer portal update subscription.</summary>
    [JsonPropertyName("customer_portal_update_subscription")]
    public string? CustomerPortalUpdateSubscription { get; init; } = null;

    /// <summary>Gets the update customer portal.</summary>
    [JsonPropertyName("update_customer_portal")]
    public string? UpdateCustomerPortal { get; init; } = null;
}
