using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Store;

/// <summary>
/// Represents a store in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Store : Model
{
    /// <summary>Gets the store attributes.</summary>
    [JsonPropertyName("attributes")]
    public StoreAttributes Attributes { get; init; } = new();
}
