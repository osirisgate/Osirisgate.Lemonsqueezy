using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Product;

/// <summary>
/// Represents a product in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Product : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public ProductAttributes Attributes { get; init; } = new();
}
