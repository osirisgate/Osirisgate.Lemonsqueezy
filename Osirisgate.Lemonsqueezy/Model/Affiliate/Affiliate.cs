using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.Affiliate;

/// <summary>
/// Represents an affiliate in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Affiliate : Model
{
    /// <summary>Gets the affiliate attributes.</summary>
    [JsonPropertyName("attributes")]
    public AffiliateAttributes Attributes { get; init; } = new();
}
