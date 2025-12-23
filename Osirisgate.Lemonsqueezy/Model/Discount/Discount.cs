using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Discount;

/// <summary>
/// Represents a discount in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Discount : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public DiscountAttributes Attributes { get; init; } = new();
}
