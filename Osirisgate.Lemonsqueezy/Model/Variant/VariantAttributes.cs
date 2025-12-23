using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Variants.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Variant;

/// <summary>
/// Represents the attributes of a variant.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class VariantAttributes
{
    /// <summary>Gets the product id.</summary>
    [JsonPropertyName("product_id")]
    public int ProductId { get; init; } = default;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the slug.</summary>
    [JsonPropertyName("slug")]
    public string Slug { get; init; } = string.Empty;

    /// <summary>Gets the description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; init; } = [];

    /// <summary>Gets the price.</summary>
    [JsonPropertyName("price")]
    public int Price { get; init; } = default;

    /// <summary>Gets the is subscription.</summary>
    [JsonPropertyName("is_subscription")]
    public bool IsSubscription { get; init; } = false;

    /// <summary>Gets the interval.</summary>
    [JsonPropertyName("interval")]
    public string? Interval { get; init; } = null;

    /// <summary>Gets the interval count.</summary>
    [JsonPropertyName("interval_count")]
    public int? IntervalCount { get; init; } = null;

    /// <summary>Gets the has free trial.</summary>
    [JsonPropertyName("has_free_trial")]
    public bool HasFreeTrial { get; init; } = false;

    /// <summary>Gets the trial interval.</summary>
    [JsonPropertyName("trial_interval")]
    public string TrialInterval { get; init; } = string.Empty;

    /// <summary>Gets the trial interval count.</summary>
    [JsonPropertyName("trial_interval_count")]
    public int TrialIntervalCount { get; init; } = default;

    /// <summary>Gets the pay what you want.</summary>
    [JsonPropertyName("pay_what_you_want")]
    public bool PayWhatYouWant { get; init; } = false;

    /// <summary>Gets the min price.</summary>
    [JsonPropertyName("min_price")]
    public int MinPrice { get; init; } = default;

    /// <summary>Gets the suggested price.</summary>
    [JsonPropertyName("suggested_price")]
    public int SuggestedPrice { get; init; } = default;

    /// <summary>Gets the has license keys.</summary>
    [JsonPropertyName("has_license_keys")]
    public bool HasLicenseKeys { get; init; } = false;

    /// <summary>Gets the license activation limit.</summary>
    [JsonPropertyName("license_activation_limit")]
    public int LicenseActivationLimit { get; init; } = default;

    /// <summary>Gets the is license limit unlimited.</summary>
    [JsonPropertyName("is_license_limit_unlimited")]
    public bool IsLicenseLimitUnlimited { get; init; } = false;

    /// <summary>Gets the license length value.</summary>
    [JsonPropertyName("license_length_value")]
    public int LicenseLengthValue { get; init; } = default;

    /// <summary>Gets the license length unit.</summary>
    [JsonPropertyName("license_length_unit")]
    public string LicenseLengthUnit { get; init; } = string.Empty;

    /// <summary>Gets the is license length unlimited.</summary>
    [JsonPropertyName("is_license_length_unlimited")]
    public bool IsLicenseLengthUnlimited { get; init; } = false;

    /// <summary>Gets the sort.</summary>
    [JsonPropertyName("sort")]
    public int Sort { get; init; } = default;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

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
