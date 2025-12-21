namespace MediaCollection.Data.Models.Media;

public class KinopoiskDataDbo
{
    public string? Id { get; set; }
    public decimal? Rating { get; set; }
    public List<string> Genres { get; set; } = new List<string>();
    public string? Description { get; set; }
}