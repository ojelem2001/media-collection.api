namespace MediaCollection.Core.Models.Media;

public class ExternalMetadata
{
    public ImdbData? Imdb { get; set; }
    public KinopoiskData? Kinopoisk { get; set; }
    public LetterboxdData? Letterboxd { get; set; }
    public TmdbData? Tmdb { get; set; }
}