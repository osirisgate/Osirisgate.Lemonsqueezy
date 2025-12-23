using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.Files.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.Files.Response;

/// <summary>
/// Represents the API response for a files relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public class FilesRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<FileResponseData> Data { get; init; } = [];
}
