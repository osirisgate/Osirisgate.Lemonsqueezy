namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Interface defining common exception handling methods for Lemonsqueezy API errors.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IException
{
    /// <summary>
    /// Gets the error code associated with this exception.
    /// </summary>
    /// <returns>The error code as an integer.</returns>
    public int GetErrorCode();

    /// <summary>
    /// Gets the main error message.
    /// </summary>
    /// <returns>The error message as a string.</returns>
    public string GetMessage();

    /// <summary>
    /// Gets the detailed error message from the exception details.
    /// </summary>
    /// <returns>The detailed error message as a string.</returns>
    public string GetDetailsMessage();

    /// <summary>
    /// Formats the exception into a structured dictionary containing status, error code, message, and details.
    /// </summary>
    /// <returns>A dictionary containing the formatted exception information.</returns>
    public IDictionary<string, object> Format();

    /// <summary>
    /// Gets all error information as a dictionary.
    /// </summary>
    /// <returns>A dictionary containing all error data.</returns>
    public IDictionary<string, object> GetErrors();

    /// <summary>
    /// Gets the exception details.
    /// </summary>
    /// <returns>A dictionary containing additional exception details.</returns>
    public IDictionary<string, object> GetDetails();
}
