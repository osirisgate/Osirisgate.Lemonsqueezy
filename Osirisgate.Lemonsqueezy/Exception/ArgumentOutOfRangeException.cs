using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when an argument value is outside the acceptable range.
/// Maps to HTTP 500 Internal Server Error status code.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ArgumentOutOfRangeException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the error code for this exception, set to InternalServerError (500).
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.InternalServerError;
}
