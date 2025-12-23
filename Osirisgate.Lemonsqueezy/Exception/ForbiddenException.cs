using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Exception thrown when the client does not have permission to access the requested resource.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class ForbiddenException(IDictionary<string, object> errors) : BaseException(errors)
{
    /// <summary>
    /// Gets the HTTP status code associated with this exception.
    /// </summary>
    protected override StatusCode ErrorCode { get; } = StatusCode.Forbidden;
}

