using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.LicenseKey;

/// <summary>
/// Represents the attributes of a license key.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyAttributes
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

    /// <summary>Gets the user name.</summary>
    [JsonPropertyName("user_name")]
    public string UserName { get; init; } = string.Empty;

    /// <summary>Gets the user email.</summary>
    [JsonPropertyName("user_email")]
    public string UserEmail { get; init; } = string.Empty;

    /// <summary>Gets the key.</summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = string.Empty;

    /// <summary>Gets the key short.</summary>
    [JsonPropertyName("key_short")]
    public string KeyShort { get; init; } = string.Empty;

    /// <summary>Gets the activation limit.</summary>
    [JsonPropertyName("activation_limit")]
    public int ActivationLimit { get; init; } = default;

    /// <summary>Gets the instances count.</summary>
    [JsonPropertyName("instances_count")]
    public int InstancesCount { get; init; } = default;

    /// <summary>Gets the disabled.</summary>
    [JsonPropertyName("disabled")]
    public bool Disabled { get; init; } = false;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

    /// <summary>Gets the expires at.</summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; init; } = null;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
