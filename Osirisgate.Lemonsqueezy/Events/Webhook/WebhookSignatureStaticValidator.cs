using System.Security.Cryptography;
using System.Text;

namespace Osirisgate.Lemonsqueezy.Events.Webhook;

/// <summary>
/// Static utility methods for validating webhook signatures from Lemonsqueezy without dependency injection.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class WebhookSignatureStaticValidator
{
    /// <summary>
    /// Validates that a webhook request comes from Lemonsqueezy by comparing the signature in the X-Signature header with a computed HMAC SHA256 hash.
    /// </summary>
    /// <param name="rawBody">The raw body of the webhook request as a string (must be the exact bytes received, not parsed JSON).</param>
    /// <param name="signature">The signature from the X-Signature header.</param>
    /// <param name="signingSecret">The signing secret configured when creating the webhook.</param>
    /// <returns>True if the signature is valid, false otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when rawBody, signature, or signingSecret is null or empty.</exception>
    public static bool ValidateSignature(string rawBody, string signature, string signingSecret) =>
        ValidateSignatureInternal(rawBody, signature, signingSecret);

    /// <summary>
    /// Validates that a webhook request comes from Lemonsqueezy using the raw body bytes.
    /// </summary>
    /// <param name="rawBodyBytes">The raw body of the webhook request as bytes (must be the exact bytes received, not parsed JSON).</param>
    /// <param name="signature">The signature from the X-Signature header.</param>
    /// <param name="signingSecret">The signing secret configured when creating the webhook.</param>
    /// <returns>True if the signature is valid, false otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when rawBodyBytes, signature, or signingSecret is null or empty.</exception>
    public static bool ValidateSignature(byte[] rawBodyBytes, string signature, string signingSecret) =>
        ValidateSignatureInternal(rawBodyBytes, signature, signingSecret);

    /// <summary>
    /// Internal method to validate signature with the signing secret.
    /// </summary>
    internal static bool ValidateSignatureInternal(string rawBody, string signature, string signingSecret)
    {
        ValidateParameter(rawBody, "rawBody", "Raw body cannot be null or empty");
        ValidateParameter(signature, "signature", "Signature cannot be null or empty");
        ValidateParameter(signingSecret, "signingSecret", "Signing secret cannot be null or empty");

        var computedHash = ComputeHmacSha256(rawBody, signingSecret);
        return ConstantTimeEquals(computedHash, signature);
    }

    /// <summary>
    /// Internal method to validate signature with the signing secret using bytes.
    /// </summary>
    internal static bool ValidateSignatureInternal(byte[] rawBodyBytes, string signature, string signingSecret)
    {
        ValidateByteParameter(rawBodyBytes, "rawBodyBytes", "Raw body bytes cannot be null or empty");
        ValidateParameter(signature, "signature", "Signature cannot be null or empty");
        ValidateParameter(signingSecret, "signingSecret", "Signing secret cannot be null or empty");

        var computedHash = ComputeHmacSha256(rawBodyBytes, signingSecret);
        return ConstantTimeEquals(computedHash, signature);
    }

    /// <summary>
    /// Computes the HMAC SHA256 hash of the raw body using the signing secret.
    /// </summary>
    /// <param name="rawBody">The raw body as a string.</param>
    /// <param name="signingSecret">The signing secret.</param>
    /// <returns>The hexadecimal hash string.</returns>
    private static string ComputeHmacSha256(string rawBody, string signingSecret)
    {
        var rawBodyBytes = Encoding.UTF8.GetBytes(rawBody);
        return ComputeHmacSha256(rawBodyBytes, signingSecret);
    }

    /// <summary>
    /// Computes the HMAC SHA256 hash of the raw body bytes using the signing secret.
    /// </summary>
    /// <param name="rawBodyBytes">The raw body as bytes.</param>
    /// <param name="signingSecret">The signing secret.</param>
    /// <returns>The hexadecimal hash string.</returns>
    private static string ComputeHmacSha256(byte[] rawBodyBytes, string signingSecret)
    {
        var secretBytes = Encoding.UTF8.GetBytes(signingSecret);

        using var hmac = new HMACSHA256(secretBytes);
        var hashBytes = hmac.ComputeHash(rawBodyBytes);
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }

    /// <summary>
    /// Performs a constant-time comparison of two strings to prevent timing attacks.
    /// </summary>
    /// <param name="a">First string to compare.</param>
    /// <param name="b">Second string to compare.</param>
    /// <returns>True if the strings are equal, false otherwise.</returns>
    private static bool ConstantTimeEquals(string a, string b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }

        var result = 0;
        for (var i = 0; i < a.Length; i++)
        {
            result |= a[i] ^ b[i];
        }

        return result == 0;
    }

    /// <summary>
    /// Validates a string parameter and throws an exception if it is null or whitespace.
    /// </summary>
    /// <param name="value">The parameter value to validate.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="message">The error message to include in the exception.</param>
    /// <exception cref="ArgumentNullException">Thrown when the value is null or whitespace.</exception>
    internal static void ValidateParameter(string value, string parameterName, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = message,
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = parameterName
                }
            });
        }
    }

    /// <summary>
    /// Validates a byte array parameter and throws an exception if it is null or empty.
    /// </summary>
    /// <param name="value">The parameter value to validate.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="message">The error message to include in the exception.</param>
    /// <exception cref="ArgumentNullException">Thrown when the value is null or empty.</exception>
    internal static void ValidateByteParameter(byte[] value, string parameterName, string message)
    {
        if (value == null || value.Length == 0)
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = message,
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = parameterName
                }
            });
        }
    }
}
