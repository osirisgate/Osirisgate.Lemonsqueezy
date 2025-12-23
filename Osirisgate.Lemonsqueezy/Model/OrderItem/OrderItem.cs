using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.OrderItem;

/// <summary>
/// Represents a order item in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class OrderItem : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public OrderItemAttributes Attributes { get; init; } = new();
}
