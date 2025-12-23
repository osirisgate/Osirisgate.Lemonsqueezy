using Microsoft.AspNetCore.Http;
using Osirisgate.Lemonsqueezy.Events.Payloads;

namespace Osirisgate.Lemonsqueezy.Extensions;

/// <summary>
/// Extension methods for accessing webhook content and parsing query parameters from HttpRequest.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class HttpRequestExtensions
{
    /// <summary>
    /// Gets the Lemonsqueezy raw webhook body from the HttpRequest's HttpContext, throwing an exception if not available.
    /// </summary>
    /// <param name="request">The HTTP request.</param>
    /// <returns>The raw webhook body as a string.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the webhook body is not available.</exception>
    public static string GetLemonsqueezyWebhookRawBody(this HttpRequest request)
    {
        return request.HttpContext.GetLemonsqueezyWebhookRawBody();
    }

    /// <summary>
    /// Deserializes the Lemonsqueezy webhook payload from the HttpRequest's HttpContext, throwing an exception if not available.
    /// </summary>
    /// <param name="request">The HTTP request.</param>
    /// <returns>The deserialized webhook payload.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the webhook body is not available.</exception>
    public static WebhookPayload GetLemonsqueezyWebhookPayload(this HttpRequest request)
    {
        return request.HttpContext.GetLemonsqueezyWebhookPayload();
    }

    /// <summary>
    /// Parses nested query parameters into a dictionary structure.
    /// Supports syntax like: filter[name]=value, page[number]=1, etc.
    /// </summary>
    /// <param name="request">The HTTP request.</param>
    /// <returns>A dictionary containing parsed query parameters with nested structure support.</returns>
    /// <example>
    /// <code>
    /// // For query string: ?filter[name]=test&page[number]=1&page[size]=10
    /// var filters = request.ParseNestedQueryParameters();
    /// // Result: { "filter": { "name": "test" }, "page": { "number": "1", "size": "10" } }
    /// </code>
    /// </example>
    public static Dictionary<string, object> ParseNestedQueryParameters(this HttpRequest request)
    {
        return ParseNestedQueryParameters(request.Query);
    }

    /// <summary>
    /// Parses nested query parameters from an IQueryCollection into a dictionary structure.
    /// Supports syntax like: filter[name]=value, page[number]=1, etc.
    /// </summary>
    /// <param name="query">The query collection from the HTTP request.</param>
    /// <returns>A dictionary containing parsed query parameters with nested structure support.</returns>
    /// <example>
    /// <code>
    /// // For query string: ?filter[name]=test&page[number]=1&page[size]=10
    /// var filters = request.Query.ParseNestedQueryParameters();
    /// // Result: { "filter": { "name": "test" }, "page": { "number": "1", "size": "10" } }
    /// </code>
    /// </example>
    public static Dictionary<string, object> ParseNestedQueryParameters(this IQueryCollection query)
    {
        var result = new Dictionary<string, object>();

        foreach (var param in query)
        {
            var key = param.Key;
            var value = param.Value.ToString();

            // Check if this is a nested parameter (e.g., filter[name])
            if (key.Contains('[') && key.Contains(']'))
            {
                var bracketIndex = key.IndexOf('[');
                var closingBracketIndex = key.IndexOf(']', bracketIndex);
                
                // Validate bracket positions
                if (bracketIndex >= 0 && closingBracketIndex > bracketIndex)
                {
                    var parentKey = key.Substring(0, bracketIndex);
                    var nestedKey = key.Substring(bracketIndex + 1, closingBracketIndex - bracketIndex - 1);

                    if (!result.TryGetValue(parentKey, out var existing))
                    {
                        existing = new Dictionary<string, object>();
                        result[parentKey] = existing;
                    }

                    if (existing is Dictionary<string, object> nestedDict)
                    {
                        nestedDict[nestedKey] = value;
                    }
                }
                else
                {
                    // Invalid bracket format, treat as simple key-value
                    result[key] = value;
                }
            }
            else
            {
                // Simple key-value parameter
                result[key] = value;
            }
        }

        return result;
    }
}
