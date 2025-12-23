using System.Net;
using Polly;
using Polly.Retry;
using Osirisgate.Lemonsqueezy.Enums;
using Osirisgate.Lemonsqueezy.Exception;
using Osirisgate.Lemonsqueezy.Model.Error;

namespace Osirisgate.Lemonsqueezy.Resource;

/// <summary>
/// Abstract base class for all Lemonsqueezy API resource endpoints.
/// Provides common HTTP methods (GET, POST, PATCH, DELETE) and utilities for API communication.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class Resource
{
    /// <summary>
    /// The default base URL for the Lemonsqueezy API.
    /// </summary>
    private const string DefaultBaseUrl = "https://api.lemonsqueezy.com/v1/";

    /// <summary>
    /// The default timeout for HTTP requests in seconds.
    /// </summary>
    private const int DefaultTimeoutSeconds = 30;

    /// <summary>
    /// The default timeout for HTTP requests.
    /// </summary>
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(DefaultTimeoutSeconds);

    /// <summary>
    /// The default number of retry attempts for transient HTTP errors.
    /// </summary>
    private const int DefaultRetryCount = 3;

    /// <summary>
    /// The Accept header value for API requests.
    /// </summary>
    private const string AcceptHeader = "application/vnd.api+json";

    /// <summary>
    /// The Content-Type header value for API requests.
    /// </summary>
    private const string ContentTypeHeader = "application/vnd.api+json";

    /// <summary>
    /// The Authorization header name.
    /// </summary>
    private const string AuthorizationHeader = "Authorization";

    /// <summary>
    /// The Accept header name.
    /// </summary>
    private const string AcceptHeaderName = "Accept";

    /// <summary>
    /// The Content-Type header name.
    /// </summary>
    private const string ContentTypeHeaderName = "Content-Type";

    /// <summary>
    /// The Bearer token prefix for authorization.
    /// </summary>
    private const string BearerPrefix = "Bearer ";

    /// <summary>
    /// Singleton HTTP client instance shared across all Resource instances.
    /// Prevents socket exhaustion and improves performance.
    /// Note: Individual request timeouts are handled via CancellationTokenSource,
    /// so this HttpClient uses a long default timeout.
    /// </summary>
    private static readonly Lazy<HttpClient> SharedHttpClient = new(() =>
    {
        var handler = new SocketsHttpHandler
        {
            AllowAutoRedirect = false,
            PooledConnectionLifetime = TimeSpan.FromMinutes(10)
        };

        return new HttpClient(handler)
        {
            // Long timeout as a safety net. Individual requests use CancellationTokenSource
            // with their configured timeout from LemonsqueezyClientOptions.
            Timeout = TimeSpan.FromMinutes(5)
        };
    }, LazyThreadSafetyMode.ExecutionAndPublication);

    /// <summary>
    /// Gets the shared singleton HTTP client instance.
    /// </summary>
    private static HttpClient HttpClient => SharedHttpClient.Value;

    /// <summary>
    /// The Lemonsqueezy client instance.
    /// </summary>
    private readonly ILemonsqueezyClient _client;

    /// <summary>
    /// The base URL for API requests, from options or default.
    /// </summary>
    private readonly string _baseUrl;

    /// <summary>
    /// The timeout for API requests, from options or default.
    /// </summary>
    private readonly TimeSpan _timeout;

    /// <summary>
    /// The retry policy for handling transient HTTP errors.
    /// </summary>
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

    /// <summary>
    /// Initializes a new instance of the Resource class.
    /// </summary>
    /// <param name="client">The Lemonsqueezy client instance.</param>
    protected Resource(ILemonsqueezyClient client)
    {
        _client = client;

        // Get options from client or use defaults
        var options = client.GetOptions();
        _baseUrl = options?.BaseUrl ?? DefaultBaseUrl;
        _timeout = options?.Timeout ?? DefaultTimeout;
        var retryCount = options?.RetryCount ?? DefaultRetryCount;

        // Initialize retry policy for transient errors (5xx and RequestTimeout)
        _retryPolicy = Policy
            .HandleResult<HttpResponseMessage>(r =>
                (int)r.StatusCode >= StatusCode.InternalServerError.GetValue() || r.StatusCode == HttpStatusCode.RequestTimeout)
            .WaitAndRetryAsync(
                retryCount: retryCount,
                sleepDurationProvider: retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    /// <summary>
    /// Initializes a new instance of the specified resource type.
    /// </summary>
    /// <typeparam name="T">The type of resource to initialize.</typeparam>
    /// <param name="client">The Lemonsqueezy client instance.</param>
    /// <returns>An instance of the specified resource type.</returns>
    public static T Init<T>(ILemonsqueezyClient client) where T : Resource
    {
        return (T)Activator.CreateInstance(typeof(T), client)!;
    }

    /// <summary>
    /// Performs an asynchronous GET request to the specified URI.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response into.</typeparam>
    /// <param name="uri">The relative URI path for the request.</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <param name="headers">Optional custom headers.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
    /// <exception cref="BadRequestContentException">Thrown when the request fails.</exception>
    protected async Task<T> GetAsync<T>(string uri, Dictionary<string, object>? filters = null, Dictionary<string, object>? headers = null, CancellationToken cancellationToken = default) where T : class
    {
        return await ExecuteHttpRequestAsync<T>(
            HttpMethod.Get,
            uri,
            requestData: null,
            filters,
            headers,
            cancellationToken
        );
    }

    /// <summary>
    /// Performs an asynchronous POST request to the specified URI.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response into.</typeparam>
    /// <param name="uri">The relative URI path for the request.</param>
    /// <param name="data">The data to send in the request body.</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <param name="headers">Optional custom headers.</param>
    /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
    /// <exception cref="BadRequestContentException">Thrown when the request fails or data is invalid.</exception>
    protected async Task<T> PostAsync<T>(string uri, Dictionary<string, object>? data = null, Dictionary<string, object>? filters = null, Dictionary<string, object>? headers = null, CancellationToken cancellationToken = default) where T : class
    {
        return await ExecuteHttpRequestAsync<T>(
            HttpMethod.Post,
            uri,
            data,
            filters,
            headers,
            cancellationToken
        );
    }

    /// <summary>
    /// Performs an asynchronous PATCH request to the specified URI.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response into.</typeparam>
    /// <param name="uri">The relative URI path for the request.</param>
    /// <param name="data">The data to send in the request body.</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <param name="headers">Optional custom headers.</param>
    /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
    /// <exception cref="BadRequestContentException">Thrown when the request fails or data is invalid.</exception>
    protected async Task<T> PatchAsync<T>(string uri, Dictionary<string, object> data, Dictionary<string, object>? filters = null, Dictionary<string, object>? headers = null, CancellationToken cancellationToken = default) where T : class
    {
        return await ExecuteHttpRequestAsync<T>(
            HttpMethod.Patch,
            uri,
            data,
            filters,
            headers,
            cancellationToken
        );
    }

    /// <summary>
    /// Performs an asynchronous DELETE request to the specified URI.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response into.</typeparam>
    /// <param name="uri">The relative URI path for the request.</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <param name="headers">Optional custom headers.</param>
    /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
    /// <exception cref="BadRequestContentException">Thrown when the request fails.</exception>
    protected async Task<T> DeleteAsync<T>(string uri, Dictionary<string, object>? filters = null, Dictionary<string, object>? headers = null, CancellationToken cancellationToken = default) where T : class
    {
        return await ExecuteHttpRequestAsync<T>(
            HttpMethod.Delete,
            uri,
            requestData: null,
            filters,
            headers,
            cancellationToken
        );
    }

    /// <summary>
    /// Executes an HTTP request with the specified method and parameters.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response into.</typeparam>
    /// <param name="method">The HTTP method to use.</param>
    /// <param name="uri">The relative URI path for the request.</param>
    /// <param name="requestData">Optional data to send in the request body (for POST/PATCH).</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <param name="headers">Optional custom headers.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
    private async Task<T> ExecuteHttpRequestAsync<T>(
        HttpMethod method,
        string uri,
        Dictionary<string, object>? requestData,
        Dictionary<string, object>? filters,
        Dictionary<string, object>? headers,
        CancellationToken cancellationToken
    ) where T : class
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await ExecuteAsync(async () =>
        {
            ValidateUri(uri);

            if (requestData != null)
            {
                ValidatePostData(requestData);

                // Validate ID presence for PATCH method
                if (method == HttpMethod.Patch)
                {
                    ValidateIdPresence(requestData);
                }
            }

            using var request = CreateRequest(uri, method, filters, headers);

            if (requestData != null)
            {
                SetRequestData(request, requestData);
            }

            // Create a CancellationTokenSource that combines the provided cancellation token
            // with the configured timeout for this resource instance
            using var timeoutCts = new CancellationTokenSource(_timeout);
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            // Execute HTTP request with retry policy for transient errors
            using var response = await _retryPolicy.ExecuteAsync(async () =>
            {
                return await HttpClient.SendAsync(request, linkedCts.Token);
            });

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response, uri, cancellationToken);
            }

            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            return DeserializeResponse<T>(responseBody, uri);
        }, uri);
    }

    /// <summary>
    /// Validates that the data dictionary contains an 'id' field.
    /// </summary>
    /// <param name="data">The data dictionary to validate.</param>
    /// <exception cref="BadRequestContentException">Thrown when the 'id' field is missing.</exception>
    protected static void ValidateIdPresence(Dictionary<string, object> data)
    {
        if (!ContainsId(data))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Request data must contain an 'id' field.",
                ["details"] = new Dictionary<string, object>
                {
                    ["data"] = data
                }
            });
        }
    }

    /// <summary>
    /// Deserializes the JSON response body into the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize into.</typeparam>
    /// <param name="responseBody">The JSON response body as a string.</param>
    /// <param name="uri">The URI that was requested.</param>
    /// <returns>The deserialized object.</returns>
    /// <exception cref="RuntimeException">Thrown when deserialization fails.</exception>
    private static T DeserializeResponse<T>(string responseBody, string uri) where T : class
    {
        try
        {
            return JsonSerializerConfig.Deserialize<T>(responseBody);
        }
        catch (System.Exception)
        {
            throw new RuntimeException(CreateDeserializationErrorContext(uri, responseBody));
        }
    }

    /// <summary>
    /// Creates an error context dictionary for deserialization failures.
    /// </summary>
    /// <param name="uri">The URI that was requested.</param>
    /// <param name="responseBody">The response body that failed to deserialize.</param>
    /// <returns>A dictionary containing error details.</returns>
    private static Dictionary<string, object> CreateDeserializationErrorContext(string uri, string responseBody)
    {
        return new Dictionary<string, object>
        {
            ["message"] = "Failed to deserialize the response.",
            ["details"] = new Dictionary<string, object>
            {
                ["uri"] = uri,
                ["responseBody"] = responseBody,
            }
        };
    }

    /// <summary>
    /// Creates and throws a BadRequestContentException with detailed error information.
    /// </summary>
    /// <param name="exception">The original exception.</param>
    /// <param name="parameters">Additional parameters to include in the error context.</param>
    /// <exception cref="BadRequestContentException">Always thrown with detailed error information.</exception>
    private static void CreateAndThrowBadRequestException(SystemException exception, Dictionary<string, object> parameters)
    {
        var errorContext = CreateErrorContext(exception, parameters);
        throw new BadRequestContentException(errorContext);
    }

    /// <summary>
    /// Creates an error context dictionary from an exception and additional parameters.
    /// </summary>
    /// <param name="exception">The exception that occurred.</param>
    /// <param name="parameters">Additional parameters to include in the error context.</param>
    /// <returns>A dictionary containing error details.</returns>
    private static Dictionary<string, object> CreateErrorContext(SystemException exception, Dictionary<string, object> parameters)
    {
        return new Dictionary<string, object>
        {
            ["message"] = "An error occurred while processing the HTTP request.",
            ["details"] = new Dictionary<string, object>
            {
                ["params"] = parameters,
                ["exception"] = new Dictionary<string, object>
                {
                    ["message"] = exception.Message,
                    ["stackTrace"] = exception.StackTrace ?? string.Empty,
                    ["rootCause"] = exception
                }
            }
        };
    }

    /// <summary>
    /// Creates an HTTP request message with the specified parameters.
    /// </summary>
    /// <param name="uri">The relative URI path.</param>
    /// <param name="method">The HTTP method to use.</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <param name="headers">Optional custom headers.</param>
    /// <returns>A configured HTTP request message.</returns>
    private HttpRequestMessage CreateRequest(string uri, HttpMethod method, Dictionary<string, object>? filters = null, Dictionary<string, object>? headers = null)
    {
        var url = BuildUrl(uri, filters);
        var request = new HttpRequestMessage(method, url);

        AddDefaultHeaders(request);
        AddCustomHeaders(request, headers);

        return request;
    }

    /// <summary>
    /// Adds default headers (Authorization and Accept) to the request.
    /// </summary>
    /// <param name="request">The HTTP request message to add headers to.</param>
    private void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add(AuthorizationHeader, $"{BearerPrefix}{_client.GetApiKey()}");
        request.Headers.Add(AcceptHeaderName, AcceptHeader);
    }

    /// <summary>
    /// Adds custom headers to the request, excluding Content-Type headers.
    /// </summary>
    /// <param name="request">The HTTP request message to add headers to.</param>
    /// <param name="customHeaders">The custom headers to add.</param>
    private static void AddCustomHeaders(HttpRequestMessage request, Dictionary<string, object>? customHeaders)
    {
        if (customHeaders == null)
            return;

        foreach (var (key, value) in customHeaders)
        {
            if (IsContentTypeHeader(key))
                continue;

            request.Headers.Add(key, value.ToString() ?? string.Empty);
        }
    }

    /// <summary>
    /// Checks if a header name is a Content-Type header.
    /// </summary>
    /// <param name="headerName">The header name to check.</param>
    /// <returns>True if it's a Content-Type header, false otherwise.</returns>
    private static bool IsContentTypeHeader(string headerName)
    {
        return headerName.Equals(ContentTypeHeaderName, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Builds a complete URL from a relative URI and optional filters.
    /// </summary>
    /// <param name="uri">The relative URI path.</param>
    /// <param name="filters">Optional query string filters.</param>
    /// <returns>The complete URL as a string.</returns>
    private string BuildUrl(string uri, Dictionary<string, object>? filters = null)
    {
        // Use native .NET Uri and UriBuilder to safely construct the URI
        var baseUri = new Uri(_baseUrl, UriKind.Absolute);
        var relativeUri = new Uri(uri, UriKind.Relative);
        var combinedUri = new Uri(baseUri, relativeUri);

        // Use UriBuilder to add query string if filters are provided
        if (filters != null && filters.Count > 0)
        {
            var queryString = BuildQueryString(filters);
            var builder = new UriBuilder(combinedUri)
            {
                Query = queryString
            };
            return builder.Uri.ToString();
        }

        return combinedUri.ToString();
    }

    /// <summary>
    /// Builds a query string from a dictionary of filters.
    /// </summary>
    /// <param name="filters">The filters to include in the query string.</param>
    /// <returns>The query string without the leading '?'.</returns>
    private static string BuildQueryString(Dictionary<string, object> filters)
    {
        var queryParts = new List<string>();

        foreach (var (key, value) in filters)
        {
            AppendFilterParameter(key, value, queryParts);
        }

        return string.Join("&", queryParts);
    }

    /// <summary>
    /// Appends a filter parameter to the query parts list, handling nested dictionaries.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    /// <param name="queryParts">The list to append the parameter to.</param>
    /// <param name="parentKey">The parent key for nested parameters.</param>
    private static void AppendFilterParameter(string key, object? value, List<string> queryParts, string? parentKey = null)
    {
        if (value == null)
            return;

        if (value is Dictionary<string, object> nestedDictionary)
        {
            AppendNestedFilterParameters(key, nestedDictionary, queryParts, parentKey);
        }
        else
        {
            AppendSimpleFilterParameter(parentKey ?? key, value, queryParts);
        }
    }

    /// <summary>
    /// Appends nested filter parameters with proper key formatting.
    /// </summary>
    /// <param name="key">The parent key.</param>
    /// <param name="nestedDictionary">The nested dictionary of parameters.</param>
    /// <param name="queryParts">The list to append parameters to.</param>
    /// <param name="parentKey">The parent key for nested parameters.</param>
    private static void AppendNestedFilterParameters(string key, Dictionary<string, object> nestedDictionary, List<string> queryParts, string? parentKey)
    {
        foreach (var (nestedKey, nestedValue) in nestedDictionary)
        {
            var fullKey = string.IsNullOrEmpty(parentKey)
                ? $"{key}[{nestedKey}]"
                : $"{parentKey}[{nestedKey}]";

            AppendFilterParameter(fullKey, nestedValue, queryParts, fullKey);
        }
    }

    /// <summary>
    /// Appends a simple (non-nested) filter parameter to the query parts list.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    /// <param name="queryParts">The list to append the parameter to.</param>
    private static void AppendSimpleFilterParameter(string key, object value, List<string> queryParts)
    {
        var encodedValue = Uri.EscapeDataString(value.ToString() ?? string.Empty);
        queryParts.Add($"{key}={encodedValue}");
    }

    /// <summary>
    /// Validates that POST/PUT/PATCH request data is not null or empty.
    /// </summary>
    /// <param name="data">The data to validate.</param>
    /// <exception cref="BadRequestContentException">Thrown when the data is null or empty.</exception>
    private static void ValidatePostData(Dictionary<string, object> data)
    {
        if (data == null || data.Count == 0)
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Request data is mandatory for POST|PUT|PATCH requests.",
                ["details"] = new Dictionary<string, object>
                {
                    ["data"] = data ?? []
                }
            });
        }
    }

    /// <summary>
    /// Checks if a data dictionary contains an 'id' field.
    /// </summary>
    /// <param name="data">The data dictionary to check.</param>
    /// <returns>True if the 'id' field exists, false otherwise.</returns>
    private static bool ContainsId(Dictionary<string, object> data)
    {
        return data?.TryGetValue("id", out _) == true;
    }

    /// <summary>
    /// Sets the request body content with the serialized data.
    /// </summary>
    /// <param name="request">The HTTP request message to set content for.</param>
    /// <param name="data">The data to serialize and set as the request body.</param>
    private static void SetRequestData(HttpRequestMessage request, Dictionary<string, object> data)
    {
        var jsonContent = JsonSerializerConfig.Serialize(data);
        request.Content = new StringContent(jsonContent, System.Text.Encoding.UTF8, ContentTypeHeader);
    }

    /// <summary>
    /// Validates that the URI is not null, empty, or contains dangerous characters.
    /// </summary>
    /// <param name="uri">The URI to validate.</param>
    /// <exception cref="BadRequestContentException">Thrown when the URI is invalid.</exception>
    private static void ValidateUri(string uri)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "URI cannot be null or empty.",
                ["details"] = new Dictionary<string, object>
                {
                    ["uri"] = uri ?? string.Empty
                }
            });
        }

        // Use native .NET methods to validate URI format
        if (!Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out var parsedUri))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Invalid URI format.",
                ["details"] = new Dictionary<string, object>
                {
                    ["uri"] = uri
                }
            });
        }

        // Check for path traversal and invalid characters using Path.GetFullPath
        // This native method will throw ArgumentException for invalid characters
        // and normalize path traversal attempts, allowing us to detect them
        try
        {
            var path = parsedUri.IsAbsoluteUri ? parsedUri.AbsolutePath : parsedUri.OriginalString;
            if (!string.IsNullOrEmpty(path))
            {
                // Normalize the path - Path.GetFullPath will resolve ".." and detect invalid characters
                var normalizedPath = Path.GetFullPath(Path.Combine("/", path.TrimStart('/')));
                // After normalization, if the path still contains "..", it's a path traversal attempt
                if (normalizedPath.Contains("..", StringComparison.Ordinal))
                {
                    throw new BadRequestContentException(new Dictionary<string, object>
                    {
                        ["message"] = "Invalid URI format. URI contains path traversal attempts.",
                        ["details"] = new Dictionary<string, object>
                        {
                            ["uri"] = uri
                        }
                    });
                }
            }
        }
        catch (ArgumentException)
        {
            // Path.GetFullPath throws ArgumentException for invalid characters
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Invalid URI format. URI contains invalid characters.",
                ["details"] = new Dictionary<string, object>
                {
                    ["uri"] = uri
                }
            });
        }

        // Check for control characters (newline, carriage return, etc.)
        if (uri.Any(char.IsControl))
        {
            throw new BadRequestContentException(new Dictionary<string, object>
            {
                ["message"] = "Invalid URI format. URI contains control characters.",
                ["details"] = new Dictionary<string, object>
                {
                    ["uri"] = uri
                }
            });
        }
    }

    /// <summary>
    /// Executes an HTTP request operation.
    /// </summary>
    /// <typeparam name="T">The return type of the operation.</typeparam>
    /// <param name="operation">The operation to execute.</param>
    /// <param name="uri">The URI being requested (for error context).</param>
    /// <returns>The result of the operation.</returns>
    private static async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, string uri)
    {
        try
        {
            return await operation();
        }
        catch (BaseException)
        {
            throw;
        }
        catch (SystemException ex)
        {
            CreateAndThrowBadRequestException(ex, new Dictionary<string, object> { ["uri"] = uri });
            throw;
        }
    }

    /// <summary>
    /// Handles HTTP error responses by parsing the error body and throwing appropriate exceptions.
    /// </summary>
    /// <param name="response">The HTTP response message. This method does not dispose the response; it is disposed by the caller.</param>
    /// <param name="uri">The URI that was requested.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <exception cref="UnauthorizedException">Thrown for HTTP 401 responses.</exception>
    /// <exception cref="NotFoundException">Thrown for HTTP 404 responses.</exception>
    /// <exception cref="BadRequestContentException">Thrown for HTTP 400 responses.</exception>
    /// <exception cref="TooManyRequestsException">Thrown for HTTP 429 responses.</exception>
    /// <exception cref="RuntimeException">Thrown for HTTP 500+ responses.</exception>
    private static async Task HandleErrorResponse(HttpResponseMessage response, string uri, CancellationToken cancellationToken)
    {
        var httpStatusCode = (int)response.StatusCode;
        var statusCode = GetStatusCodeFromHttpStatus(httpStatusCode);
        var errorBody = await response.Content.ReadAsStringAsync(cancellationToken);

        var errorDetails = new Dictionary<string, object>
        {
            ["uri"] = uri,
            ["statusCode"] = httpStatusCode,
            ["errors"] = new Dictionary<string, object>()
        };

        if (!string.IsNullOrWhiteSpace(errorBody))
        {
            // Try to deserialize error response
            try
            {
                var errorResponse = JsonSerializerConfig.Deserialize<ErrorResponse>(errorBody);
                errorDetails["jsonapi"] = errorResponse.JsonApi;
                errorDetails["errors"] = errorResponse.Errors;
            }
            catch (System.Exception)
            {
                // If deserialization fails, use the raw body
            }
        }

        var errorContext = new Dictionary<string, object>
        {
            ["message"] = $"HTTP {httpStatusCode} error occurred.",
            ["details"] = errorDetails
        };

        // Handle rate limiting
        if (statusCode == StatusCode.TooManyRequests)
        {
            throw new TooManyRequestsException(errorContext);
        }

        // Map HTTP status codes to appropriate exceptions
        throw statusCode switch
        {
            StatusCode.Unauthorized => new UnauthorizedException(errorContext),
            StatusCode.Forbidden => new ForbiddenException(errorContext),
            StatusCode.NotFound => new NotFoundException(errorContext),
            StatusCode.BadRequest => new BadRequestContentException(errorContext),
            StatusCode.InternalServerError => new RuntimeException(errorContext),
            _ => httpStatusCode >= StatusCode.InternalServerError.GetValue()
                ? new RuntimeException(errorContext)
                : new BadRequestContentException(errorContext)
        };
    }

    /// <summary>
    /// Converts an HTTP status code integer to the corresponding StatusCode enum value.
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code as an integer.</param>
    /// <returns>The corresponding StatusCode enum value, or BadRequest if not mapped.</returns>
    private static StatusCode GetStatusCodeFromHttpStatus(int httpStatusCode)
    {
        return httpStatusCode switch
        {
            400 => StatusCode.BadRequest,
            403 => StatusCode.Forbidden,
            401 => StatusCode.Unauthorized,
            404 => StatusCode.NotFound,
            429 => StatusCode.TooManyRequests,
            500 => StatusCode.InternalServerError,
            _ => httpStatusCode >= 500
                ? StatusCode.InternalServerError
                : StatusCode.BadRequest
        };
    }
}