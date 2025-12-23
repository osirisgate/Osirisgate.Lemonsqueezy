using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Checkout.ValueObject;

/// <summary>
/// Represents a checkout data in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CheckoutData
{
    /// <summary>Gets the email.</summary>
    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the billing address.</summary>
    [JsonPropertyName("billing_address")]
    public BillingAddress BillingAddress { get; init; } = new();

    /// <summary>Gets the tax number.</summary>
    [JsonPropertyName("tax_number")]
    public string TaxNumber { get; init; } = string.Empty;

    /// <summary>Gets the discount code.</summary>
    [JsonPropertyName("discount_code")]
    public string DiscountCode { get; init; } = string.Empty;

    /// <summary>Gets the custom data.</summary>
    [JsonPropertyName("custom")]
    public Dictionary<string, object> Custom { get; init; } = [];

    /// <summary>Gets the variant quantities.</summary>
    [JsonPropertyName("variant_quantities")]
    public List<VariantQuantity> VariantQuantities { get; init; } = [];
}
