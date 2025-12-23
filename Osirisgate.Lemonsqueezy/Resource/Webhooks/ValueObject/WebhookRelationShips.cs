using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Webhooks.ValueObject;

/// <summary>
/// Represents the relationship links for a webhook.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class WebhookRelationShips
{
    /// <summary>Gets the store.</summary>
    [JsonPropertyName("store")]
    public RelationShipLink Store { get; init; } = new();
}
