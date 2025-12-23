using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Webhook;

/// <summary>
/// Represents a webhook in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Webhook : Model
{
    /// <summary>Gets the webhook attributes.</summary>
    [JsonPropertyName("attributes")]
    public WebhookAttributes Attributes { get; init; } = new();
}
