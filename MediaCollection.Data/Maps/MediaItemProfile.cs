using AutoMapper;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class MediaItemProfile : Profile
{
    public MediaItemProfile()
    {
        CreateMap<MediaItemDbo, MediaItem>();
        CreateMap<MediaItem, MediaItemDbo>();
    }
}
