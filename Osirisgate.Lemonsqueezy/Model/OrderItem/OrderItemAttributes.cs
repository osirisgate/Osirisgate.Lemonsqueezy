using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.OrderItem;

/// <summary>
/// Represents the attributes of a order item.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class OrderItemAttributes
{
    /// <summary>Gets the order id.</summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; init; } = default;

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

    /// <summary>Gets the price.</summary>
    [JsonPropertyName("price")]
    public int Price { get; init; } = default;

    /// <summary>Gets the quantity.</summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; } = default;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
