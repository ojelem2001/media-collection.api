using System.Text.Json.Serialization;

namespace MediaCollection.Core.Models.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MediaType
{
    [JsonPropertyName("MOVIE")]
    Movie = 1,

    [JsonPropertyName("SERIES")]
    Series = 2,

    [JsonPropertyName("BOOK")]
    Book = 3,

    [JsonPropertyName("GAME")]
    Game = 4,

    [JsonPropertyName("MUSIC")]
    Music = 5,

    [JsonPropertyName("COMIX")]
    Comix = 6
}