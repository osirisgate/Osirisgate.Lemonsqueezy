using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Checkout.ValueObject;

/// <summary>
/// Represents a billing address in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class BillingAddress
{
    /// <summary>Gets the country.</summary>
    [JsonPropertyName("country")]
    public string Country { get; init; } = string.Empty;

    /// <summary>Gets the zip.</summary>
    [JsonPropertyName("zip")]
    public string Zip { get; init; } = string.Empty;
}
