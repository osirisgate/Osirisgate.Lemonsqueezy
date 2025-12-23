using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.ValueObject;

/// <summary>
/// Represents a meta item current usage in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class MetaItemCurrentUsage
{
    /// <summary>Gets the period start.</summary>
    [JsonPropertyName("period_start")]
    public string PeriodStart { get; init; } = string.Empty;

    /// <summary>Gets the period end.</summary>
    [JsonPropertyName("period_end")]
    public string PeriodEnd { get; init; } = string.Empty;

    /// <summary>Gets the quantity.</summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; } = default;

    /// <summary>Gets the interval unit.</summary>
    [JsonPropertyName("interval_unit")]
    public string IntervalUnit { get; init; } = string.Empty;

    /// <summary>Gets the interval quantity.</summary>
    [JsonPropertyName("interval_quantity")]
    public int IntervalQuantity { get; init; } = default;
}
