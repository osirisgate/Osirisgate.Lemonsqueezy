using System.Text.Json;
using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Exception;

namespace Osirisgate.Lemonsqueezy;

/// <summary>
/// Centralized configuration for JSON serialization and deserialization.
/// Provides consistent JSON handling across the SDK.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class JsonSerializerConfig
{
    /// <summary>
    /// Default JSON serializer options configured for the SDK.
    /// </summary>
    public static readonly JsonSerializerOptions Default = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>
    /// Deserializes a JSON string into the specified type using the default configuration.
    /// </summary>
    /// <typeparam name="T">The type to deserialize into.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    /// <exception cref="RuntimeException">Thrown when deserialization fails.</exception>
    public static T Deserialize<T>(string json) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json, Default)
                ?? throw new RuntimeException(new Dictionary<string, object>
                {
                    ["message"] = $"Failed to deserialize {typeof(T).Name}",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["type"] = typeof(T).Name,
                        ["json"] = json
                    }
                });
        }
        catch (JsonException ex)
        {
            throw new RuntimeException(new Dictionary<string, object>
            {
                ["message"] = $"JSON deserialization failed: {ex.Message}",
                ["details"] = new Dictionary<string, object> { ["json"] = json }
            });
        }
    }

    /// <summary>
    /// Serializes an object to a JSON string using the default configuration.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The JSON string representation of the object.</returns>
    public static string Serialize<T>(T value)
    {
        return JsonSerializer.Serialize(value, Default);
    }
}
