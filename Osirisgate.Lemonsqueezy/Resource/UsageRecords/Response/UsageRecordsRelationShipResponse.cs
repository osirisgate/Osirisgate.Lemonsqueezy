using System.Text.Json.Serialization;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.ValueObject;

namespace Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

/// <summary>
/// Represents the API response for a usage records relation ship.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UsageRecordsRelationShipResponse : RelationShipResponse
{
    /// <summary>Gets the data.</summary>
    [JsonPropertyName("data")]
    public List<UsageRecordResponseData> Data { get; init; } = [];
}
