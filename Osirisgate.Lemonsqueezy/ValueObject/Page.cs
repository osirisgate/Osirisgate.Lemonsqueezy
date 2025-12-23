using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.ValueObject;

/// <summary>
/// Represents pagination information for API responses.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class Page
{
    /// <summary>Gets the current page number.</summary>
    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; init; } = default;

    /// <summary>Gets the starting item index on the current page.</summary>
    [JsonPropertyName("from")]
    public int From { get; init; } = default;

    /// <summary>Gets the last page number.</summary>
    [JsonPropertyName("lastPage")]
    public int LastPage { get; init; } = default;

    /// <summary>Gets the number of items per page.</summary>
    [JsonPropertyName("perPage")]
    public int PerPage { get; init; } = default;

    /// <summary>Gets the ending item index on the current page.</summary>
    [JsonPropertyName("to")]
    public int To { get; init; } = default;

    /// <summary>Gets the total number of items.</summary>
    [JsonPropertyName("total")]
    public int Total { get; init; } = default;
}
