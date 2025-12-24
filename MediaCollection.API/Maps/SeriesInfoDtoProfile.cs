using AutoMapper;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class SeriesInfoDtoProfile : Profile
{
    public SeriesInfoDtoProfile()
    {
        CreateMap<SeriesInfoDto, SeriesInfo>();
        CreateMap<SeriesInfo, SeriesInfoDto>();
    }
}
