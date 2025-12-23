using Osirisgate.Lemonsqueezy.Exception;

namespace Osirisgate.Lemonsqueezy;

/// <summary>
/// Configuration options for the Lemonsqueezy client.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public class LemonsqueezyClientOptions
{
    /// <summary>
    /// Default base URL for the Lemonsqueezy API.
    /// </summary>
    internal const string DefaultBaseUrl = "https://api.lemonsqueezy.com/v1/";

    /// <summary>
    /// Default timeout for HTTP requests in seconds.
    /// </summary>
    internal const int DefaultTimeoutSeconds = 30;

    /// <summary>
    /// Default number of retry attempts for transient HTTP errors.
    /// </summary>
    internal const int DefaultRetryCount = 3;

    private string _apiKey = string.Empty;
    private string _baseUrl = DefaultBaseUrl;
    private TimeSpan _timeout = TimeSpan.FromSeconds(DefaultTimeoutSeconds);
    private int _retryCount = DefaultRetryCount;

    /// <summary>
    /// Initializes a new instance of LemonsqueezyClientOptions with the specified API key.
    /// </summary>
    /// <param name="apiKey">The API key for authenticating with the Lemonsqueezy API.</param>
    /// <exception cref="ArgumentNullException">Thrown when apiKey is null or empty.</exception>
    private LemonsqueezyClientOptions(string apiKey)
    {
        ValidateApiKey(apiKey);
        _apiKey = apiKey;
    }

    /// <summary>
    /// Initializes a new instance of LemonsqueezyClientOptions with default values.
    /// The API key must be set via the WithApiKey method and will be validated.
    /// </summary>
    private LemonsqueezyClientOptions()
    {
    }

    /// <summary>
    /// Creates a new instance of LemonsqueezyClientOptions from the specified API key.
    /// </summary>
    /// <param name="apiKey">The API key for authenticating with the Lemonsqueezy API.</param>
    /// <returns>A new instance of LemonsqueezyClientOptions.</returns>
    /// <exception cref="ArgumentNullException">Thrown when apiKey is null or empty.</exception>
    public static LemonsqueezyClientOptions From(string apiKey)
    {
        return new LemonsqueezyClientOptions(apiKey);
    }

    /// <summary>
    /// Creates a new instance of LemonsqueezyClientOptions with default values.
    /// The API key must be set via the WithApiKey method and will be validated.
    /// </summary>
    /// <returns>A new instance of LemonsqueezyClientOptions with default values.</returns>
    public static LemonsqueezyClientOptions From()
    {
        return new LemonsqueezyClientOptions();
    }

    /// <summary>
    /// Gets the API key for authenticating with the Lemonsqueezy API.
    /// </summary>
    public string ApiKey => _apiKey;

    /// <summary>
    /// Gets the base URL for the Lemonsqueezy API.
    /// </summary>
    public string BaseUrl => _baseUrl;

    /// <summary>
    /// Gets the timeout for HTTP requests.
    /// </summary>
    public TimeSpan Timeout => _timeout;

    /// <summary>
    /// Gets the number of retry attempts for transient HTTP errors (5xx and RequestTimeout).
    /// </summary>
    public int RetryCount => _retryCount;

    /// <summary>
    /// Sets the API key for authenticating with the Lemonsqueezy API.
    /// </summary>
    /// <param name="apiKey">The API key.</param>
    /// <returns>The current instance for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when apiKey is null or empty.</exception>
    public LemonsqueezyClientOptions WithApiKey(string apiKey)
    {
        ValidateApiKey(apiKey);
        _apiKey = apiKey;
        return this;
    }

    /// <summary>
    /// Sets the base URL for the Lemonsqueezy API.
    /// </summary>
    /// <param name="baseUrl">The base URL.</param>
    /// <returns>The current instance for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when baseUrl is null or empty.</exception>
    /// <exception cref="BadRequestContentException">Thrown when baseUrl is not a valid HTTP or HTTPS URL.</exception>
    public LemonsqueezyClientOptions WithBaseUrl(string baseUrl)
    {
        ValidateBaseUrl(baseUrl);
        _baseUrl = baseUrl;
        return this;
    }

    /// <summary>
    /// Sets the timeout for HTTP requests.
    /// </summary>
    /// <param name="timeout">The timeout duration.</param>
    /// <returns>The current instance for method chaining.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when timeout is less than or equal to zero.</exception>
    public LemonsqueezyClientOptions WithTimeout(TimeSpan timeout)
    {
        ValidateTimeout(timeout);
        _timeout = timeout;
        return this;
    }

    /// <summary>
    /// Sets the number of retry attempts for transient HTTP errors (5xx and RequestTimeout).
    /// </summary>
    /// <param name="retryCount">The number of retry attempts.</param>
    /// <returns>The current instance for method chaining.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when retryCount is negative.</exception>
    public LemonsqueezyClientOptions WithRetryCount(int retryCount)
    {
        ValidateRetryCount(retryCount);
        _retryCount = retryCount;
        return this;
    }

    private static void ValidateApiKey(string? apiKey)
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = "API key cannot be null or empty.",
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = nameof(ApiKey)
                }
            });
        }
    }

    private static void ValidateBaseUrl(string? baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = "Base URL cannot be null or empty.",
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = nameof(BaseUrl)
                }
            });
        }

        if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Base URL must be a valid HTTP or HTTPS URL.",
                ["details"] = new Dictionary<string, object>
                {
                    ["baseUrl"] = baseUrl,
                    ["parameterName"] = nameof(BaseUrl)
                }
            });
        }
    }

    private static void ValidateTimeout(TimeSpan timeout)
    {
        if (timeout <= TimeSpan.Zero)
        {
            throw new Exception.ArgumentOutOfRangeException(new Dictionary<string, object>
            {
                ["message"] = "Timeout must be greater than zero.",
                ["details"] = new Dictionary<string, object>
                {
                    ["timeout"] = timeout.ToString(),
                    ["parameterName"] = nameof(Timeout)
                }
            });
        }
    }

    private static void ValidateRetryCount(int retryCount)
    {
        if (retryCount < 0)
        {
            throw new Exception.ArgumentOutOfRangeException(new Dictionary<string, object>
            {
                ["message"] = "Retry count cannot be negative.",
                ["details"] = new Dictionary<string, object>
                {
                    ["retryCount"] = retryCount,
                    ["parameterName"] = nameof(RetryCount)
                }
            });
        }
    }
}

