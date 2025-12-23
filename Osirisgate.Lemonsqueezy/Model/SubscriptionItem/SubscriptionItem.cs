using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.SubscriptionItem;

/// <summary>
/// Represents a subscription item in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class SubscriptionItem : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public SubscriptionItemAttributes Attributes { get; init; } = new();
}
