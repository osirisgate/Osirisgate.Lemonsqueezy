using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.Response;

/// <summary>
/// Represents the API response for a generate subscription invoice.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public class GenerateSubscriptionInvoiceResponse
{
    /// <summary>Gets the json api.</summary>
    [JsonPropertyName("jsonapi")]
    public JsonApi JsonApi { get; init; } = new();

    /// <summary>Gets the meta.</summary>
    [JsonPropertyName("meta")]
    public MetaUrl Meta { get; init; } = new();
}
