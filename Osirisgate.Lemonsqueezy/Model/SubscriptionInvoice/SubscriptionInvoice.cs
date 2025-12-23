using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.SubscriptionInvoice;

/// <summary>
/// Represents a subscription invoice in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class SubscriptionInvoice : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public SubscriptionInvoiceAttributes Attributes { get; init; } = new();
}
