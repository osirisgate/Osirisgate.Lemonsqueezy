using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when the request content is invalid or malformed.
/// Maps to HTTP 400 Bad Request status code.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class BadRequestContentException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the error code for this exception, set to BadRequest (400).
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.BadRequest;
}
