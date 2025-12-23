using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Price;

/// <summary>
/// Represents a price in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Price : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public PriceAttributes Attributes { get; init; } = new();
}
