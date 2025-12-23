using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.DiscountRedemption;

/// <summary>
/// Represents a discount redemption in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class DiscountRedemption : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public DiscountRedemptionAttributes Attributes { get; init; } = new();
}
