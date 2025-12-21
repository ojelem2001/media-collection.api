using MediaCollection.Core.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Data.Models.User;

public class UserCollectionItemDbo
{
    public int Id { get; set; }
    public int? PersonalRating { get; set; } // 1-10
    public string? PersonalNotes { get; set; }
    public DateTime? DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "Planned";

    public int? CurrentSeason { get; set; }
    public int? CurrentEpisode { get; set; }
    public int? CurrentChapter { get; set; }
    public int? CurrentPage { get; set; }

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public int CollectionId { get; set; }
    public virtual UserCollectionDbo Collection { get; set; } = null!;

    public int MediaItemId { get; set; }
    public virtual MediaItemDbo MediaItem { get; set; } = null!;
}