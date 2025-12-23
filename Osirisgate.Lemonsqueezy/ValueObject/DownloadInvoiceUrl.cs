using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents a download invoice url in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class DownloadInvoiceUrl
{
    /// <summary>Gets the download invoice.</summary>
    [JsonPropertyName("download_invoice")]
    public string DownloadInvoice { get; init; } = string.Empty;
}
