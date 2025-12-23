using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when the rate limit has been exceeded.
/// Maps to HTTP 429 Too Many Requests status code.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class TooManyRequestsException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the error code for this exception, set to TooManyRequests (429).
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.TooManyRequests;
}
