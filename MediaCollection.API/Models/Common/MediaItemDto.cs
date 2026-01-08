using MediaCollection.Core.Models.Enum;
using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Common;

/// <summary>
/// Информация медиа продукте
/// </summary>
public class MediaItemDto
{
    [JsonPropertyName("guid")]
    public Guid? Guid { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("originalTitle")]
    public string? OriginalTitle { get; set; }

    [JsonPropertyName("type")]
    public required MediaType Type { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("isWatched")]
    public long IsWatched { get; set; }

    [JsonPropertyName("posterUrl")]
    public string? PosterUrl { get; set; }

    [JsonPropertyName("seriesInfo")]
    public SeriesInfoDto? SeriesInfo { get; set; }

    [JsonPropertyName("aggregators")]
    public IEnumerable<AggregatorsDto>? Aggregators { get; set; }
}