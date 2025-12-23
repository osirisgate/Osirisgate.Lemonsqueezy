namespace Osirisgate.Lemonsqueezy.Enums;

/// <summary>
/// Enumeration representing the status of API operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public enum Status
{
    /// <summary>
    /// Indicates a successful operation.
    /// </summary>
    Success = 1,

    /// <summary>
    /// Indicates an error occurred during the operation.
    /// </summary>
    Error = 2,
}

/// <summary>
/// Extension methods for the Status enumeration.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class StatusExtensions
{
    /// <summary>
    /// Converts the Status enum value to its string representation.
    /// </summary>
    /// <param name="status">The status value to convert.</param>
    /// <returns>The string representation of the status ("success" or "error").</returns>
    /// <exception cref="Exception.ArgumentOutOfRangeException">Thrown when the status value is unknown.</exception>
    public static string GetValue(this Status status)
    {
        return status switch
        {
            Status.Success => "success",
            Status.Error => "error",
            _ => throw new Exception.ArgumentOutOfRangeException(new Dictionary<string, object>
            {
                ["message"] = "Unknown status",
                ["details"] = new Dictionary<string, object>
                {
                    ["status"] = status.ToString()
                }
            }),
        };
    }
}
