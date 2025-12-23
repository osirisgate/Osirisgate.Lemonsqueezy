using Osirisgate.Lemonsqueezy.Enums;

namespace Osirisgate.Lemonsqueezy.Exception;

/// <summary>
/// Base exception class for all Lemonsqueezy API exceptions.
/// Provides common functionality for error handling and formatting.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class BaseException : System.Exception, IException
{
    /// <summary>
    /// Gets the status code associated with this exception. Default is BadRequest.
    /// </summary>
    protected virtual StatusCode ErrorCode { get; } = StatusCode.BadRequest;

    /// <summary>
    /// The dictionary containing all error information.
    /// </summary>
    private readonly IDictionary<string, object> _errors;

    /// <summary>
    /// Initializes a new instance of the BaseException class.
    /// </summary>
    /// <param name="errors">A dictionary containing error information, including the message.</param>
    protected BaseException(IDictionary<string, object> errors)
        : base(errors.TryGetValue("message", out _) ? errors["message"].ToString() : string.Empty)
    {
        _errors = errors;
    }

    /// <summary>
    /// Formats the exception into a structured dictionary.
    /// </summary>
    /// <returns>A dictionary containing status, error code, message, and details.</returns>
    public IDictionary<string, object> Format()
    {
        return new Dictionary<string, object>
        {
            ["status"] = Status.Error.GetValue(),
            ["error_code"] = ErrorCode.GetValue(),
            ["message"] = GetMessage(),
            ["details"] = GetDetails(),
        };
    }

    /// <summary>
    /// Gets all error information.
    /// </summary>
    /// <returns>A dictionary containing all error data.</returns>
    public IDictionary<string, object> GetErrors()
    {
        return _errors;
    }

    /// <summary>
    /// Gets the exception details from the error dictionary.
    /// </summary>
    /// <returns>A dictionary containing additional exception details, or an empty dictionary if no details exist.</returns>
    public IDictionary<string, object> GetDetails()
    {
        return _errors.TryGetValue("details", out var details) && details is IDictionary<string, object> dict
            ? dict
            : new Dictionary<string, object>();
    }

    /// <summary>
    /// Gets the detailed error message from the exception details.
    /// </summary>
    /// <returns>The error message from the details, or an empty string if no error detail exists.</returns>
    public string GetDetailsMessage()
    {
        if (GetDetails().TryGetValue("error", out var error) && error is string errorMessage)
        {
            return errorMessage;
        }
        return string.Empty;
    }

    /// <summary>
    /// Gets the main error message.
    /// </summary>
    /// <returns>The error message as a string.</returns>
    public string GetMessage()
    {
        return Message;
    }

    /// <summary>
    /// Gets the error code associated with this exception.
    /// </summary>
    /// <returns>The error code as an integer.</returns>
    public int GetErrorCode()
    {
        return ErrorCode.GetValue();
    }
}
