using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when a null argument is passed to a method that does not accept it.
/// Maps to HTTP 400 Bad Request status code.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ArgumentNullException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the error code for this exception, set to BadRequest (400).
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.BadRequest;
}
