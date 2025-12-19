namespace MediaCollection.Core.Models.Media;

public class ImdbData
{
    public string? Id { get; set; }
    public decimal? Rating { get; set; }
    public List<string> Genres { get; set; } = new List<string>();
}