namespace MediaCollection.Core.Models.Media;

public class KinopoiskData
{
    public string? Id { get; set; }
    public decimal? Rating { get; set; }
    public List<string> Genres { get; set; } = new List<string>();
    public string? Description { get; set; }
}