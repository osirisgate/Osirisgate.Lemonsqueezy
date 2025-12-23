using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.Response;

/// <summary>
/// Represents the API response for a subscription invoices relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionInvoicesRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<SubscriptionInvoiceResponseData> Data { get; init; } = [];
}