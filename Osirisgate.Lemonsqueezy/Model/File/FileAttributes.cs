using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.File;

/// <summary>
/// Represents the attributes of a file.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class FileAttributes
{
    /// <summary>Gets the variant id.</summary>
    [JsonPropertyName("variant_id")]
    public int VariantId { get; init; } = default;

    /// <summary>Gets the identifier.</summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; } = string.Empty;

    /// <summary>Gets the name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the extension.</summary>
    [JsonPropertyName("extension")]
    public string Extension { get; init; } = string.Empty;

    /// <summary>Gets the download url.</summary>
    [JsonPropertyName("download_url")]
    public string DownloadUrl { get; init; } = string.Empty;

    /// <summary>Gets the size.</summary>
    [JsonPropertyName("size")]
    public int Size { get; init; } = default;

    /// <summary>Gets the size formatted.</summary>
    [JsonPropertyName("size_formatted")]
    public string SizeFormatted { get; init; } = string.Empty;

    /// <summary>Gets the version.</summary>
    [JsonPropertyName("version")]
    public string Version { get; init; } = string.Empty;

    /// <summary>Gets the sort.</summary>
    [JsonPropertyName("sort")]
    public int Sort { get; init; } = default;

    /// <summary>Gets the status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    /// <summary>Gets the created at.</summary>
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the updated at.</summary>
    [JsonPropertyName("updatedAt")]
    public string UpdatedAt { get; init; } = string.Empty;

    /// <summary>Gets the test mode.</summary>
    [JsonPropertyName("test_mode")]
    public bool TestMode { get; init; } = default;
}
