using MediaCollection.Core.Models.Enum;
using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Media;

/// <summary>
/// Информация медиа продукте
/// </summary>
public class MediaItemDto
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

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

    [JsonPropertyName("posterUrl")]
    public string? PosterUrl { get; set; }

    [JsonPropertyName("seriesInfo")]
    public SeriesInfoDto? SeriesInfo { get; set; }

    [JsonPropertyName("imdb")]
    public AggregatorsDto? Imdb { get; set; }

    [JsonPropertyName("letterboxd")]
    public AggregatorsDto? Letterboxd { get; set; }

    [JsonPropertyName("kinopoisk")]
    public AggregatorsDto? Kinopoisk { get; set; }
}