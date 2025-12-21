namespace MediaCollection.Data.Models.Media;

public class ImdbDataDbo
{
    public string? Id { get; set; }
    public decimal? Rating { get; set; }
    public List<string> Genres { get; set; } = [];
}