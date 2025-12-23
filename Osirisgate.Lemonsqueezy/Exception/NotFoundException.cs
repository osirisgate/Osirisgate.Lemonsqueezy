using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when a requested resource is not found.
/// Maps to HTTP 404 Not Found status code.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class NotFoundException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the error code for this exception, set to NotFound (404).
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.NotFound;
}

