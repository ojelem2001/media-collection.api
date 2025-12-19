namespace MediaCollection.API.Models.Media;

public class SeriesInfoDto
{
    public int? Seasons { get; set; }
    public int? Episodes { get; set; }
    public int? EndYear { get; set; }
    public string? Status { get; set; }
}