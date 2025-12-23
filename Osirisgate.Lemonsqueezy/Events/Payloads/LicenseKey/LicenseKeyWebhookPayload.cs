using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.ValueObject;

namespace Osirisgate.Lemonsqueezy.Events.Payloads.LicenseKey;

/// <summary>
/// Represents a webhook payload for license key events (license_key_created, license_key_updated).
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class LicenseKeyWebhookPayload : WebhookPayload
{
    /// <summary>Gets the license key data.</summary>
    [JsonPropertyName("data")]
    public LicenseKeyResponseData Data { get; init; } = new();
}
