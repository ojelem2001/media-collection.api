using MediaCollection.Core.Models.Enum;

namespace MediaCollection.Core.Models.Media;

/// <summary>
/// Аггрегатор информации о медиа продукте
/// </summary>
public class Aggregators
{
    public long? Id { get; set; }

    public required string Number { get; set; }

    public AggregatorType Type { get; set; }

    public decimal? Rating { get; set; }

    public List<string>? Genres { get; set; }

    public string? Description { get; set; }

    public DateTime? Updated { get; set; }

    public DateTime? Created { get; set; }
}