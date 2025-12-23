using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Checkout.ValueObject;

/// <summary>
/// Represents a product options in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ProductOptions
{
    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    /// <summary>Gets the media.</summary>
    [JsonPropertyName("media")]
    public List<string> Media { get; init; } = [];

    /// <summary>Gets the redirect url.</summary>
    [JsonPropertyName("redirect_url")]
    public string RedirectUrl { get; init; } = string.Empty;

    /// <summary>Gets the receipt button text.</summary>
    [JsonPropertyName("receipt_button_text")]
    public string ReceiptButtonText { get; init; } = string.Empty;

    /// <summary>Gets the receipt link url.</summary>
    [JsonPropertyName("receipt_link_url")]
    public string ReceiptLinkUrl { get; init; } = string.Empty;

    /// <summary>Gets the receipt thank you note.</summary>
    [JsonPropertyName("receipt_thank_you_note")]
    public string ReceiptThankYouNote { get; init; } = string.Empty;

    /// <summary>Gets the enabled variants.</summary>
    [JsonPropertyName("enabled_variants")]
    public List<int> EnabledVariants { get; init; } = [];
}
