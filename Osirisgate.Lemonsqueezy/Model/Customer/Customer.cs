using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Customer;

/// <summary>
/// Represents a customer in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Customer : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public CustomerAttributes Attributes { get; init; } = new();
}
