using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Product;

/// <summary>
/// Represents the attributes of a product.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ProductAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the slug.</summary>
    [JsonPropertyName("slug")]
    public string Slug { get; init; } = string.Empty;

    /// <summary>Gets the description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

    /// <summary>Gets the thumb url.</summary>
    [JsonPropertyName("thumb_url")]
    public string ThumbUrl { get; init; } = string.Empty;

    /// <summary>Gets the large thumb url.</summary>
    [JsonPropertyName("large_thumb_url")]
    public string LargeThumbUrl { get; init; } = string.Empty;

    /// <summary>Gets the price.</summary>
    [JsonPropertyName("price")]
    public int Price { get; init; } = default;

    /// <summary>Gets the price formatted.</summary>
    [JsonPropertyName("price_formatted")]
    public string PriceFormatted { get; init; } = string.Empty;

    /// <summary>Gets the from price.</summary>
    [JsonPropertyName("from_price")]
    public int? FromPrice { get; init; } = null;

    /// <summary>Gets the to price.</summary>
    [JsonPropertyName("to_price")]
    public int? ToPrice { get; init; } = null;

    /// <summary>Gets the pay what you want.</summary>
    [JsonPropertyName("pay_what_you_want")]
    public bool PayWhatYouWant { get; init; } = false;

    /// <summary>Gets the buy now url.</summary>
    [JsonPropertyName("buy_now_url")]
    public string BuyNowUrl { get; init; } = string.Empty;

    /// <summary>Gets the from price formatted.</summary>
    [JsonPropertyName("from_price_formatted")]
    public string? FromPriceFormatted { get; init; } = null;

    /// <summary>Gets the to price formatted.</summary>
    [JsonPropertyName("to_price_formatted")]
    public string? ToPriceFormatted { get; init; } = null;

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
