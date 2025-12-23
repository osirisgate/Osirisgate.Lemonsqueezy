using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.ValueObject;

/// <summary>
/// Represents the API response for a subscription item data.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class SubscriptionItemResponseData : Model.SubscriptionItem.SubscriptionItem
{
    /// <summary>Gets the links.</summary>
    [JsonPropertyName("links")]
    public SingleLink Links { get; init; } = new();

    /// <summary>Gets the relationships.</summary>
    [JsonPropertyName("relationships")]
    public SubscriptionItemRelationShip Relationships { get; init; } = new();
}
