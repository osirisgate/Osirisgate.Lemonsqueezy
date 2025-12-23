using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents the customer portal URL.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class CustomerPortalUrl
{
    /// <summary>Gets the customer portal URL.</summary>
    [JsonPropertyName("customer_portal")]
    public string? CustomerPortal { get; init; } = null;
}
