using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when authentication fails or credentials are invalid.
/// Maps to HTTP 401 Unauthorized status code.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UnauthorizedException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the error code for this exception, set to Unauthorized (401).
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.Unauthorized;
}
