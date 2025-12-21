namespace MediaCollection.Data.Models.Media;

/// <summary>
/// Информация о сериале
/// </summary>
public class SeriesInfoDbo
{
    public int? Seasons { get; set; }
    public int? Episodes { get; set; }
    public int? EndYear { get; set; }
    public string? Status { get; set; } // Завершен, продолжается и т.д.
}