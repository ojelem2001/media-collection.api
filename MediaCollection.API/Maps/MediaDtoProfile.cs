using AutoMapper;
using MediaCollection.API.Models.Common;
using MediaCollection.Core.Models.Enum;
using MediaCollection.Core.Models.Media;
using Microsoft.OpenApi.Extensions;

namespace MediaCollection.Data.Maps;
 
public class MediaDtoProfile : Profile
{
    public MediaDtoProfile()
    {
        CreateMap<MediaItemDto, MediaItem>()
            .ForMember(dest => dest.UserGuid, opt => opt.MapFrom((src, dest, member, context) => (Guid)context.Items["UserGuid"]))
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid ?? Guid.NewGuid()));
        CreateMap<MediaItem, MediaItemDto>();

        CreateMap<SeriesInfoDto, SeriesInfo>();
        CreateMap<SeriesInfo, SeriesInfoDto>();

        CreateMap<AggregatorsDto, Aggregators>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.GetEnumFromDisplayName<AggregatorType>()));
        CreateMap<Aggregators, AggregatorsDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.GetDisplayName()));
    }
}
