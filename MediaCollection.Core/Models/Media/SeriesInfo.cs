namespace MediaCollection.Core.Models.Media;

/// <summary>
/// Информация о сериале
/// </summary>
public class SeriesInfo
{
    public long? Id { get; set; }

    public int? Seasons { get; set; }

    public int? Episodes { get; set; }

    public int? EndYear { get; set; }

    public DateTime? Updated { get; set; }

    public DateTime? Created { get; set; }
}