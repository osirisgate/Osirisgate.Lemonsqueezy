using Osirisgate.Lemonsqueezy.Exception;

namespace Osirisgate.Lemonsqueezy.Events;

/// <summary>
/// Enumeration representing all webhook event types available in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public enum WebhookEvent
{
    // Order Events
    /// <summary>
    /// Triggered when a new order is successfully placed.
    /// </summary>
    OrderCreated = 1,

    /// <summary>
    /// Triggered when a full or partial refund is issued for an order.
    /// </summary>
    OrderRefunded = 2,

    // Subscription Events
    /// <summary>
    /// Triggered when a new subscription is successfully created. An order_created event accompanies this event.
    /// </summary>
    SubscriptionCreated = 100,

    /// <summary>
    /// Triggered when a subscription's data is changed or updated. This event serves as a catch-all to ensure you have the latest subscription data.
    /// </summary>
    SubscriptionUpdated = 101,

    /// <summary>
    /// Triggered when a subscription is manually cancelled by the customer or store owner. The subscription enters a grace period until the next billing date, during which it can be resumed.
    /// </summary>
    SubscriptionCancelled = 102,

    /// <summary>
    /// Triggered when a previously cancelled subscription is resumed.
    /// </summary>
    SubscriptionResumed = 103,

    /// <summary>
    /// Triggered when a subscription ends after being cancelled or once dunning has been completed for past-due subscriptions.
    /// </summary>
    SubscriptionExpired = 104,

    /// <summary>
    /// Triggered when a subscription's payment collection is paused.
    /// </summary>
    SubscriptionPaused = 105,

    /// <summary>
    /// Triggered when a subscription's payment collection is resumed after being paused.
    /// </summary>
    SubscriptionUnpaused = 106,

    /// <summary>
    /// Triggered when a subscription payment is successful.
    /// </summary>
    SubscriptionPaymentSuccess = 107,

    /// <summary>
    /// Triggered when a subscription renewal payment fails.
    /// </summary>
    SubscriptionPaymentFailed = 108,

    /// <summary>
    /// Triggered when a subscription has a successful payment after a failed payment. An accompanying subscription_payment_success event is also sent.
    /// </summary>
    SubscriptionPaymentRecovered = 109,

    /// <summary>
    /// Triggered when a subscription payment is refunded.
    /// </summary>
    SubscriptionPaymentRefunded = 110,

    // License Key Events
    /// <summary>
    /// Triggered when a license key is created from a new order. An order_created event accompanies this event.
    /// </summary>
    LicenseKeyCreated = 200,

    /// <summary>
    /// Triggered when a license key is updated.
    /// </summary>
    LicenseKeyUpdated = 201,

    // Affiliate Events
    /// <summary>
    /// Triggered when an affiliate is activated.
    /// </summary>
    AffiliateActivated = 300,
}

/// <summary>
/// Extension methods for the WebhookEvent enumeration.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class WebhookEventExtensions
{
    /// <summary>
    /// Converts the WebhookEvent enum value to its string representation used by the Lemonsqueezy API.
    /// </summary>
    /// <param name="webhookEvent">The webhook event value to convert.</param>
    /// <returns>The string representation of the event (e.g., "order_created", "subscription_updated").</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the event value is unknown.</exception>
    public static string GetValue(this WebhookEvent webhookEvent)
    {
        return webhookEvent switch
        {
            // Order Events
            WebhookEvent.OrderCreated => "order_created",
            WebhookEvent.OrderRefunded => "order_refunded",

            // Subscription Events
            WebhookEvent.SubscriptionCreated => "subscription_created",
            WebhookEvent.SubscriptionUpdated => "subscription_updated",
            WebhookEvent.SubscriptionCancelled => "subscription_cancelled",
            WebhookEvent.SubscriptionResumed => "subscription_resumed",
            WebhookEvent.SubscriptionExpired => "subscription_expired",
            WebhookEvent.SubscriptionPaused => "subscription_paused",
            WebhookEvent.SubscriptionUnpaused => "subscription_unpaused",
            WebhookEvent.SubscriptionPaymentSuccess => "subscription_payment_success",
            WebhookEvent.SubscriptionPaymentFailed => "subscription_payment_failed",
            WebhookEvent.SubscriptionPaymentRecovered => "subscription_payment_recovered",
            WebhookEvent.SubscriptionPaymentRefunded => "subscription_payment_refunded",

            // License Key Events
            WebhookEvent.LicenseKeyCreated => "license_key_created",
            WebhookEvent.LicenseKeyUpdated => "license_key_updated",

            // Affiliate Events
            WebhookEvent.AffiliateActivated => "affiliate_activated",

            _ => throw new Exception.ArgumentOutOfRangeException(new Dictionary<string, object>
            {
                ["message"] = "Unknown webhook event",
                ["details"] = new Dictionary<string, object>
                {
                    ["event"] = webhookEvent.ToString()
                }
            }),
        };
    }

    /// <summary>
    /// Converts a string representation to the corresponding WebhookEvent enum value.
    /// </summary>
    /// <param name="value">The string value to convert (e.g., "order_created", "subscription_updated").</param>
    /// <returns>The corresponding WebhookEvent enum value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the string value is unknown.</exception>
    public static WebhookEvent FromValue(string value)
    {
        return value switch
        {
            // Order Events
            "order_created" => WebhookEvent.OrderCreated,
            "order_refunded" => WebhookEvent.OrderRefunded,

            // Subscription Events
            "subscription_created" => WebhookEvent.SubscriptionCreated,
            "subscription_updated" => WebhookEvent.SubscriptionUpdated,
            "subscription_cancelled" => WebhookEvent.SubscriptionCancelled,
            "subscription_resumed" => WebhookEvent.SubscriptionResumed,
            "subscription_expired" => WebhookEvent.SubscriptionExpired,
            "subscription_paused" => WebhookEvent.SubscriptionPaused,
            "subscription_unpaused" => WebhookEvent.SubscriptionUnpaused,
            "subscription_payment_success" => WebhookEvent.SubscriptionPaymentSuccess,
            "subscription_payment_failed" => WebhookEvent.SubscriptionPaymentFailed,
            "subscription_payment_recovered" => WebhookEvent.SubscriptionPaymentRecovered,
            "subscription_payment_refunded" => WebhookEvent.SubscriptionPaymentRefunded,

            // License Key Events
            "license_key_created" => WebhookEvent.LicenseKeyCreated,
            "license_key_updated" => WebhookEvent.LicenseKeyUpdated,

            // Affiliate Events
            "affiliate_activated" => WebhookEvent.AffiliateActivated,

            _ => throw new Exception.ArgumentOutOfRangeException(new Dictionary<string, object>
            {
                ["message"] = "Unknown webhook event value",
                ["details"] = new Dictionary<string, object>
                {
                    ["value"] = value
                }
            }),
        };
    }

    /// <summary>
    /// Checks if the current webhook event matches the specified event type.
    /// </summary>
    /// <param name="webhookEvent">The webhook event to check.</param>
    /// <param name="eventType">The event type to compare against.</param>
    /// <returns>True if the event matches the specified type, false otherwise.</returns>
    public static bool IsEventType(this WebhookEvent webhookEvent, WebhookEvent eventType)
    {
        return webhookEvent == eventType;
    }

    /// <summary>
    /// Checks if the current webhook event matches any of the specified event types.
    /// </summary>
    /// <param name="webhookEvent">The webhook event to check.</param>
    /// <param name="eventTypes">The event types to compare against.</param>
    /// <returns>True if the event matches any of the specified types, false otherwise.</returns>
    public static bool IsEventType(this WebhookEvent webhookEvent, params WebhookEvent[] eventTypes)
    {
        return eventTypes.Contains(webhookEvent);
    }

}
