using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.ValueObject;

/// <summary>
/// Represents the API response for a subscription invoice data.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionInvoiceResponseData : Model.SubscriptionInvoice.SubscriptionInvoice
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the relation ships.</summary>
    [JsonPropertyName("relationships")]
    public SubscriptionInvoiceRelationShips RelationShips { get; init; } = new();
}
