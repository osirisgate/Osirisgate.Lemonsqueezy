using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents a meta url in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class MetaUrl
{
    /// <summary>Gets the urls.</summary>
    [JsonPropertyName("urls")]
    public DownloadInvoiceUrl Urls { get; init; } = new();
}
