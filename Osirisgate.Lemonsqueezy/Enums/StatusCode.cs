namespace Osirisgate.Lemonsqueezy.Enums;

/// <summary>
/// Enumeration representing HTTP status codes used in API responses.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public enum StatusCode
{
    /// <summary>
    /// Indicates a bad request with invalid or missing parameters (HTTP 400).
    /// </summary>
    BadRequest = 400,

    /// <summary>
    /// Indicates that authentication is required or has failed (HTTP 401).
    /// </summary>
    Unauthorized = 401,

    /// <summary>
    /// Indicates that the client does not have permission to access the requested resource (HTTP 403).
    /// </summary>
    Forbidden = 403,

    /// <summary>
    /// Indicates that the requested resource was not found (HTTP 404).
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// Indicates that the rate limit has been exceeded (HTTP 429).
    /// </summary>
    TooManyRequests = 429,

    /// <summary>
    /// Indicates an internal server error (HTTP 500).
    /// </summary>
    InternalServerError = 500,
}

/// <summary>
/// Extension methods for the StatusCode enumeration.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class StatusCodeExtensions
{
    /// <summary>
    /// Converts the StatusCode enum value to its integer representation.
    /// </summary>
    /// <param name="statusCode">The status code to convert.</param>
    /// <returns>The integer value of the status code.</returns>
    public static int GetValue(this StatusCode statusCode)
    {
        return (int)statusCode;
    }
}
