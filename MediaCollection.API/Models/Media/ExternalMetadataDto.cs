namespace MediaCollection.API.Models.Media;

public class ExternalMetadataDto
{
    public ImdbDataDto? Imdb { get; set; }
    public KinopoiskDataDto? Kinopoisk { get; set; }
    public LetterboxdDataDto? Letterboxd { get; set; }
    public TmdbDataDto? Tmdb { get; set; }
}