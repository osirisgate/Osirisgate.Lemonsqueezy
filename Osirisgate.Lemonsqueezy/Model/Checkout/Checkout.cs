using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Checkout;

/// <summary>
/// Represents a checkout in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Checkout : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public CheckoutAttributes Attributes { get; init; } = new();
}
