using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Order.ValueObject;

/// <summary>
/// Represents a receipt url in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ReceiptUrl
{
    /// <summary>Gets the url.</summary>
    [JsonPropertyName("receipt")]
    public string Receipt { get; init; } = string.Empty;
}
