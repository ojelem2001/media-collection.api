using AutoMapper;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class MediaItemDtoProfile : Profile
{
    public MediaItemDtoProfile()
    {
        CreateMap<MediaItemDto, MediaItem>();
        CreateMap<MediaItem, MediaItemDto>();
    }
}
