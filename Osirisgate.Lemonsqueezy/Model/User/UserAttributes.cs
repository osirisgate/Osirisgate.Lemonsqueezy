using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.User;

/// <summary>
/// Represents the attributes of a user.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UserAttributes
{
    /// <summary>Gets the user name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Gets the user email.</summary>
    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    /// <summary>Gets the user color theme.</summary>
    [JsonPropertyName("color")]
    public string Color { get; init; } = string.Empty;

    /// <summary>Gets the avatar URL.</summary>
    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; init; } = string.Empty;

    /// <summary>Gets whether the user has a custom avatar.</summary>
    [JsonPropertyName("has_custom_avatar")]
    public bool HasCustomAvatar { get; init; } = false;

    /// <summary>Gets the creation timestamp.</summary>
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; init; } = string.Empty;

    /// <summary>Gets the last update timestamp.</summary>
    [JsonPropertyName("updatedAt")]
    public string UpdatedAt { get; init; } = string.Empty;
}
