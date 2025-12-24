using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Media;

/// <summary>
/// Информация о сериале
/// </summary>
public class SeriesInfoDto
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("seasons")]
    public int? Seasons { get; set; }

    [JsonPropertyName("episodes")]
    public int? Episodes { get; set; }

    [JsonPropertyName("endYear")]
    public int? EndYear { get; set; }
}