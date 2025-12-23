using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Model.Customer;

/// <summary>
/// Represents the attributes of a customer.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CustomerAttributes
{
    /// <summary>Gets the store id.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the email.</summary>
    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the city.</summary>
    [JsonPropertyName("city")]
    public string? City { get; init; } = null;

    /// <summary>Gets the region.</summary>
    [JsonPropertyName("region")]
    public string? Region { get; init; } = null;

    /// <summary>Gets the country.</summary>
    [JsonPropertyName("country")]
    public string Country { get; init; } = string.Empty;

    /// <summary>Gets the total revenue currency.</summary>
    [JsonPropertyName("total_revenue_currency")]
    public int TotalRevenueCurrency { get; init; } = default;

    /// <summary>Gets the mrr.</summary>
    [JsonPropertyName("mrr")]
    public int Mrr { get; init; } = default;

    /// <summary>Gets the status formatted.</summary>
    [JsonPropertyName("status_formatted")]
    public string StatusFormatted { get; init; } = string.Empty;

    /// <summary>Gets the country formatted.</summary>
    [JsonPropertyName("country_formatted")]
    public string CountryFormatted { get; init; } = string.Empty;

    /// <summary>Gets the total revenue currency formatted.</summary>
    [JsonPropertyName("total_revenue_currency_formatted")]
    public string TotalRevenueCurrencyFormatted { get; init; } = string.Empty;

    /// <summary>Gets the mrr formatted.</summary>
    [JsonPropertyName("mrr_formatted")]
    public string MrrFormatted { get; init; } = string.Empty;

    /// <summary>Gets the urls.</summary>
    [JsonPropertyName("urls")]
    public CustomerPortalUrl Urls { get; init; } = new();

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
