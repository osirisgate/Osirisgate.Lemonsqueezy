using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.UsageRecord;

/// <summary>
/// Represents a usage record in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class UsageRecord : Model
{
    /// <summary>Gets the attributes.</summary>
    [JsonPropertyName("attributes")]
    public UsageRecordAttributes Attributes { get; init; } = new();
}
