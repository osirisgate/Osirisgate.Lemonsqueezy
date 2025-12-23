using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Order;

/// <summary>
/// Represents a order in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Order : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public OrderAttributes Attributes { get; init; } = new();
}
