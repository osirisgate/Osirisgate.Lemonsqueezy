using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Affiliate;

/// <summary>
/// Represents the attributes of an affiliate.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class AffiliateAttributes
{
    /// <summary>Gets the store ID.</summary>
    [JsonPropertyName("store_id")]
    public int StoreId { get; init; } = default;

    /// <summary>Gets the user ID.</summary>
    [JsonPropertyName("user_id")]
    public int UserId { get; init; } = default;

    /// <summary>Gets the user name.</summary>
    [JsonPropertyName("user_name")]
    public string UserName { get; init; } = string.Empty;

    /// <summary>Gets the user email.</summary>
    [JsonPropertyName("user_email")]
    public string UserEmail { get; init; } = string.Empty;

    /// <summary>Gets the affiliate share domain.</summary>
    [JsonPropertyName("share_domain")]
    public string ShareDomain { get; init; } = string.Empty;

    /// <summary>Gets the affiliate status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the list of products associated with the affiliate.</summary>
    [JsonPropertyName("products")]
    public List<Product.Product>? Products { get; init; } = null;

    /// <summary>Gets the application note.</summary>
    [JsonPropertyName("application_note")]
    public string ApplicationNote { get; init; } = string.Empty;

    /// <summary>Gets the total earnings.</summary>
    [JsonPropertyName("total_earnings")]
    public int TotalEarnings { get; init; } = default;

    /// <summary>Gets the unpaid earnings.</summary>
    [JsonPropertyName("unpaid_earnings")]
    public int UnpaidEarnings { get; init; } = default;

    /// <summary>Gets the creation timestamp.</summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the last update timestamp.</summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; } = string.Empty;
}
