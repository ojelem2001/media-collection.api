using AutoMapper;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class MediaDboProfile : Profile
{
    public MediaDboProfile()
    {
        CreateMap<MediaItemDbo, MediaItem>();
        CreateMap<MediaItem, MediaItemDbo>();

        CreateMap<AggregatorsDbo, Aggregators>();
        CreateMap<Aggregators, AggregatorsDbo>();

        CreateMap<SeriesInfoDbo, SeriesInfo>();
        CreateMap<SeriesInfo, SeriesInfoDbo>();
    }
}
