using MediaCollection.API.Models.Media;

namespace MediaCollection.API.Models;

public class MediaItemListResponse
{
    public List<MediaItemDto> Items { get; set; } = new List<MediaItemDto>();
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}