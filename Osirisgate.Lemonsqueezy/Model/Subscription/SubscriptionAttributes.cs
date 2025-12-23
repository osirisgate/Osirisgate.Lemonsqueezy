using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.Subscription.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Subscription;

/// <summary>
/// Represents the attributes of a subscription.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the customer id.</summary>
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; init; } = default;

    /// <summary>Gets the order id.</summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; init; } = default;

    /// <summary>Gets the order item id.</summary>
    [JsonPropertyName("order_item_id")]
    public int OrderItemId { get; init; } = default;

    /// <summary>Gets the product id.</summary>
    [JsonPropertyName("product_id")]
    public int ProductId { get; init; } = default;

    /// <summary>Gets the variant id.</summary>
    [JsonPropertyName("variant_id")]
    public int VariantId { get; init; } = default;

    /// <summary>Gets the product name.</summary>
    [JsonPropertyName("product_name")]
    public string ProductName { get; init; } = string.Empty;

    /// <summary>Gets the variant name.</summary>
    [JsonPropertyName("variant_name")]
    public string VariantName { get; init; } = string.Empty;

    /// <summary>Gets the user name.</summary>
    [JsonPropertyName("user_name")]
    public string UserName { get; init; } = string.Empty;

    /// <summary>Gets the user email.</summary>
    [JsonPropertyName("user_email")]
    public string UserEmail { get; init; } = string.Empty;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

    /// <summary>Gets the card brand.</summary>
    [JsonPropertyName("card_brand")]
    public string CardBrand { get; init; } = string.Empty;

    /// <summary>Gets the card last four.</summary>
    [JsonPropertyName("card_last_four")]
    public string CardLastFour { get; init; } = string.Empty;

    /// <summary>Gets the payment processor.</summary>
    [JsonPropertyName("payment_processor")]
    public string PaymentProcessor { get; init; } = string.Empty;

    /// <summary>Gets the pause.</summary>
    [JsonPropertyName("pause")]
    public Pause? Pause { get; init; } = null;

    /// <summary>Gets the cancelled.</summary>
    [JsonPropertyName("cancelled")]
    public bool Cancelled { get; init; } = false;

    /// <summary>Gets the trial ends at.</summary>
    [JsonPropertyName("trial_ends_at")]
    public string? TrialEndsAt { get; init; } = null;

    /// <summary>Gets the billing anchor.</summary>
    [JsonPropertyName("billing_anchor")]
    public int BillingAnchor { get; init; } = default;

    /// <summary>Gets the first subscription item.</summary>
    [JsonPropertyName("first_subscription_item")]
    public FirstSubscriptionItem? FirstSubscriptionItem { get; init; } = null;

    /// <summary>Gets the urls.</summary>
    [JsonPropertyName("urls")]
    public SubscriptionUrl Urls { get; init; } = new();

    /// <summary>Gets the renews at.</summary>
    [JsonPropertyName("renews_at")]
    public string RenewsAt { get; init; } = string.Empty;

    /// <summary>Gets the ends at.</summary>
    [JsonPropertyName("ends_at")]
    public string? EndsAt { get; init; } = null;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;

    /// <summary>Gets the test mode.</summary>
    [JsonPropertyName("test_mode")]
    public bool TestMode { get; init; } = false;
}
