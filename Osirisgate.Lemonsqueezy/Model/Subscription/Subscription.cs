using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Subscription;

/// <summary>
/// Represents a subscription in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Subscription : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public SubscriptionAttributes Attributes { get; init; } = new();
}
