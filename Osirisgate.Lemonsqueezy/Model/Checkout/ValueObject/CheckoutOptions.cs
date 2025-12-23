using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Checkout.ValueObject;

/// <summary>
/// Represents a checkout options in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CheckoutOptions
{
    /// <summary>Gets the embed.</summary>
    [JsonPropertyName("embed")]
    public bool Embed { get; init; } = false;

    /// <summary>Gets the media.</summary>
    [JsonPropertyName("media")]
    public bool Media { get; init; } = false;

    /// <summary>Gets the logo.</summary>
    [JsonPropertyName("logo")]
    public bool Logo { get; init; } = false;

    /// <summary>Gets the desc.</summary>
    [JsonPropertyName("desc")]
    public bool Desc { get; init; } = false;

    /// <summary>Gets the discount.</summary>
    [JsonPropertyName("discount")]
    public bool Discount { get; init; } = false;

    /// <summary>Gets the subscription preview.</summary>
    [JsonPropertyName("subscription_preview")]
    public bool SubscriptionPreview { get; init; } = false;

    /// <summary>Gets the background color.</summary>
    [JsonPropertyName("background_color")]
    public string BackgroundColor { get; init; } = string.Empty;

    /// <summary>Gets the headings color.</summary>
    [JsonPropertyName("headings_color")]
    public string HeadingsColor { get; init; } = string.Empty;

    /// <summary>Gets the primary text color.</summary>
    [JsonPropertyName("primary_text_color")]
    public string PrimaryTextColor { get; init; } = string.Empty;

    /// <summary>Gets the secondary text color.</summary>
    [JsonPropertyName("secondary_text_color")]
    public string SecondaryTextColor { get; init; } = string.Empty;

    /// <summary>Gets the links color.</summary>
    [JsonPropertyName("links_color")]
    public string LinksColor { get; init; } = string.Empty;

    /// <summary>Gets the borders color.</summary>
    [JsonPropertyName("borders_color")]
    public string BordersColor { get; init; } = string.Empty;

    /// <summary>Gets the checkbox color.</summary>
    [JsonPropertyName("checkbox_color")]
    public string CheckboxColor { get; init; } = string.Empty;

    /// <summary>Gets the active state color.</summary>
    [JsonPropertyName("active_state_color")]
    public string ActiveStateColor { get; init; } = string.Empty;

    /// <summary>Gets the button color.</summary>
    [JsonPropertyName("button_color")]
    public string ButtonColor { get; init; } = string.Empty;

    /// <summary>Gets the button text color.</summary>
    [JsonPropertyName("button_text_color")]
    public string ButtonTextColor { get; init; } = string.Empty;

    /// <summary>Gets the terms privacy color.</summary>
    [JsonPropertyName("terms_privacy_color")]
    public string TermsPrivacyColor { get; init; } = string.Empty;

    /// <summary>Gets the dark.</summary>
    [JsonPropertyName("dark")]
    public bool Dark { get; init; } = false;
}
