using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.LicenseApi.ValueObject;

/// <summary>
/// Represents a meta in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class Meta
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the order id.</summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; init; } = default;

    /// <summary>Gets the order item id.</summary>
    [JsonPropertyName("order_item_id")]
    public int OrderItemId { get; init; } = default;

    /// <summary>Gets the product id.</summary>
    [JsonPropertyName("product_id")]
    public int ProductId { get; init; } = default;

    /// <summary>Gets the product name.</summary>
    [JsonPropertyName("product_name")]
    public string ProductName { get; init; } = string.Empty;

    /// <summary>Gets the variant id.</summary>
    [JsonPropertyName("variant_id")]
    public int VariantId { get; init; } = default;

    /// <summary>Gets the variant name.</summary>
    [JsonPropertyName("variant_name")]
    public string VariantName { get; init; } = string.Empty;

    /// <summary>Gets the customer id.</summary>
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; init; } = default;

    /// <summary>Gets the customer name.</summary>
    [JsonPropertyName("customer_name")]
    public string CustomerName { get; init; } = string.Empty;

    /// <summary>Gets the customer email.</summary>
    [JsonPropertyName("customer_email")]
    public string CustomerEmail { get; init; } = string.Empty;
}
