namespace Osirisgate.Lemonsqueezy.Events.Webhook;

/// <summary>
/// Implementation for validating webhook signatures from Lemonsqueezy.
/// Can be instantiated with a signing secret for dependency injection.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class WebhookSignatureValidator : IWebhookSignatureValidator
{
    private readonly string _signingSecret;

    /// <summary>
    /// Initializes a new instance of the WebhookSignatureValidator with the specified signing secret.
    /// </summary>
    /// <param name="signingSecret">The signing secret configured when creating the webhook.</param>
    /// <exception cref="Exception.ArgumentOutOfRangeException">Thrown when signingSecret is null or empty.</exception>
    public WebhookSignatureValidator(string signingSecret)
    {
        WebhookSignatureStaticValidator.ValidateParameter(signingSecret, "signingSecret", "Signing secret cannot be null or empty");
        _signingSecret = signingSecret;
    }

    /// <summary>
    /// Validates that a webhook request comes from Lemonsqueezy by comparing the signature in the X-Signature header with a computed HMAC SHA256 hash.
    /// </summary>
    /// <param name="rawBody">The raw body of the webhook request as a string (must be the exact bytes received, not parsed JSON).</param>
    /// <param name="signature">The signature from the X-Signature header.</param>
    /// <returns>True if the signature is valid, false otherwise.</returns>
    /// <exception cref="Exception.ArgumentOutOfRangeException">Thrown when rawBody or signature is null or empty.</exception>
    public bool ValidateSignature(string rawBody, string signature) =>
        WebhookSignatureStaticValidator.ValidateSignatureInternal(rawBody, signature, _signingSecret);

    /// <summary>
    /// Validates that a webhook request comes from Lemonsqueezy using the raw body bytes.
    /// </summary>
    /// <param name="rawBodyBytes">The raw body of the webhook request as bytes (must be the exact bytes received, not parsed JSON).</param>
    /// <param name="signature">The signature from the X-Signature header.</param>
    /// <returns>True if the signature is valid, false otherwise.</returns>
    /// <exception cref="Exception.ArgumentOutOfRangeException">Thrown when rawBodyBytes or signature is null or empty.</exception>
    public bool ValidateSignature(byte[] rawBodyBytes, string signature) =>
        WebhookSignatureStaticValidator.ValidateSignatureInternal(rawBodyBytes, signature, _signingSecret);
}
