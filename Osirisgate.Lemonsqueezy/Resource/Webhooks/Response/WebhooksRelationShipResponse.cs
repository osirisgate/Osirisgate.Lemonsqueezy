using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

/// <summary>
/// Represents the API response for a webhooks relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class WebhooksRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<WebhookResponseData> Data { get; init; } = [];
}