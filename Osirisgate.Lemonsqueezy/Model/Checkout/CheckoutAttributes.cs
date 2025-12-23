using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Model.Checkout.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Checkout;

/// <summary>
/// Represents the attributes of a checkout.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CheckoutAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the variant id.</summary>
    [JsonPropertyName("variant_id")]
    public int VariantId { get; init; } = default;

    /// <summary>Gets the custom price.</summary>
    [JsonPropertyName("custom_price")]
    public int? CustomPrice { get; init; } = null;

    /// <summary>Gets the product options.</summary>
    [JsonPropertyName("product_options")]
    public ProductOptions ProductOptions { get; init; } = new();

    /// <summary>Gets the checkout options.</summary>
    [JsonPropertyName("checkout_options")]
    public CheckoutOptions CheckoutOptions { get; init; } = new();

    /// <summary>Gets the checkout data.</summary>
    [JsonPropertyName("checkout_data")]
    public CheckoutData CheckoutData { get; init; } = new();

    /// <summary>Gets the preview.</summary>
    [JsonPropertyName("preview")]
    public Preview? Preview { get; init; } = null;

    /// <summary>Gets the expires at.</summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; init; } = null;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;

    /// <summary>Gets the test mode.</summary>
    [JsonPropertyName("test_mode")]
    public bool TestMode { get; init; } = false;

    /// <summary>Gets the url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;
}
