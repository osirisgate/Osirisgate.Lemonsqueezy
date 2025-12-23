using System.Text.Json.Serialization;

namespace Osirisgate.Lemonsqueezy.Model.User;

/// <summary>
/// Represents a user in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public abstract class User : Model
{
    /// <summary>Gets the user attributes.</summary>
    [JsonPropertyName("attributes")]
    public UserAttributes Attributes { get; init; } = new();
}
