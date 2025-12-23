using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.SubscriptionInvoice.ValueObject;

/// <summary>
/// Represents a invoice urls in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class InvoiceUrls
{
    /// <summary>Gets the invoice url.</summary>
    [JsonPropertyName("invoice_url")]
    public string? InvoiceUrl { get; init; } = null;
}
