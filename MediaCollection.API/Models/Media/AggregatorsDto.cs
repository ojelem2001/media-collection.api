using MediaCollection.Core.Models.Enum;
using System.Text.Json.Serialization;

namespace MediaCollection.API.Models.Media;

/// <summary>
/// Аггрегатор информации о медиа продукте
/// </summary>
public class AggregatorsDto
{
    [JsonPropertyName("id")]
    public required string Number { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("rating")]
    public decimal? Rating { get; set; }

    [JsonPropertyName("genres")]
    public List<string>? Genres { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}