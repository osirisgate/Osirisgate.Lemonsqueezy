using System.Text.Json;
using Osirisgate.Lemonsqueezy.Events.Payloads.Affiliate;
using Osirisgate.Lemonsqueezy.Events.Payloads.LicenseKey;
using Osirisgate.Lemonsqueezy.Events.Payloads.Order;
using Osirisgate.Lemonsqueezy.Events.Payloads.Subscription;
using Osirisgate.Lemonsqueezy.Exception;

namespace Osirisgate.Lemonsqueezy.Events.Payloads;

/// <summary>
/// Utility class for deserializing webhook payloads based on event type.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class WebhookPayloadDeserializer
{
    /// <summary>
    /// Deserializes a webhook payload JSON string into the appropriate payload type based on the event name.
    /// </summary>
    /// <param name="json">The JSON string containing the webhook payload.</param>
    /// <param name="options">Optional JSON serializer options. If null, default options are used.</param>
    /// <returns>The deserialized webhook payload.</returns>
    /// <exception cref="BadRequestContentException">Thrown when the event name is unknown, unsupported, or the payload format is invalid.</exception>
    public static WebhookPayload Deserialize(string json, JsonSerializerOptions? options = null)
    {
        options ??= JsonSerializerConfig.Default;

        // First, deserialize to get the meta.event_name
        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        if (!root.TryGetProperty("meta", out var metaElement) ||
            !metaElement.TryGetProperty("event_name", out var eventNameElement))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Webhook payload missing meta.event_name",
                ["details"] = new Dictionary<string, object>
                {
                    ["json"] = json
                }
            });
        }

        var eventName = eventNameElement.GetString() ?? string.Empty;

        // Deserialize based on event type
        return eventName switch
        {
            "order_created" or "order_refunded" => JsonSerializer.Deserialize<OrderWebhookPayload>(json, options)
                ?? throw new BadRequestContentException(new Dictionary<string, object>
                {
                    ["message"] = "Failed to deserialize order webhook payload",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["event_name"] = eventName
                    }
                }),

            "subscription_created" or "subscription_updated" or "subscription_cancelled" or
            "subscription_resumed" or "subscription_expired" or "subscription_paused" or
            "subscription_unpaused" => JsonSerializer.Deserialize<SubscriptionWebhookPayload>(json, options)
                ?? throw new BadRequestContentException(new Dictionary<string, object>
                {
                    ["message"] = "Failed to deserialize subscription webhook payload",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["event_name"] = eventName
                    }
                }),

            "subscription_payment_success" or "subscription_payment_failed" or
            "subscription_payment_recovered" or "subscription_payment_refunded" =>
                JsonSerializer.Deserialize<SubscriptionPaymentWebhookPayload>(json, options)
                ?? throw new BadRequestContentException(new Dictionary<string, object>
                {
                    ["message"] = "Failed to deserialize subscription payment webhook payload",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["event_name"] = eventName
                    }
                }),

            "license_key_created" or "license_key_updated" =>
                JsonSerializer.Deserialize<LicenseKeyWebhookPayload>(json, options)
                ?? throw new BadRequestContentException(new Dictionary<string, object>
                {
                    ["message"] = "Failed to deserialize license key webhook payload",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["event_name"] = eventName
                    }
                }),

            "affiliate_activated" => JsonSerializer.Deserialize<AffiliateWebhookPayload>(json, options)
                ?? throw new BadRequestContentException(new Dictionary<string, object>
                {
                    ["message"] = "Failed to deserialize affiliate webhook payload",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["event_name"] = eventName
                    }
                }),

            _ => throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Unknown or unsupported webhook event type",
                ["details"] = new Dictionary<string, object>
                {
                    ["event_name"] = eventName
                }
            })
        };
    }

    /// <summary>
    /// Gets the event type enum from a webhook payload raw body string without fully deserializing the payload.
    /// This method is more performant than deserializing the entire payload when you only need to check the event type.
    /// </summary>
    /// <param name="rawBody">The raw body string containing the webhook payload JSON.</param>
    /// <returns>The corresponding WebhookEvent enum value.</returns>
    /// <exception cref="BadRequestContentException">Thrown when the payload format is invalid or missing meta.event_name.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the event name is unknown (maps to HTTP 500).</exception>
    public static WebhookEvent GetEventTypeFromRawBody(string rawBody)
    {
        using var document = JsonDocument.Parse(rawBody);
        var root = document.RootElement;

        if (!root.TryGetProperty("meta", out var metaElement) ||
            !metaElement.TryGetProperty("event_name", out var eventNameElement))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Webhook payload missing meta.event_name",
                ["details"] = new Dictionary<string, object>
                {
                    ["rawBody"] = rawBody
                }
            });
        }

        var eventName = eventNameElement.GetString() ?? string.Empty;
        return WebhookEventExtensions.FromValue(eventName);
    }
}
