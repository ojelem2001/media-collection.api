namespace MediaCollection.Data.Models.Media;

public class ExternalMetadataDbo
{
    public ImdbDataDbo? Imdb { get; set; }
    public KinopoiskDataDbo? Kinopoisk { get; set; }
    public LetterboxdDataDbo? Letterboxd { get; set; }
    public TmdbDataDbo? Tmdb { get; set; }
}