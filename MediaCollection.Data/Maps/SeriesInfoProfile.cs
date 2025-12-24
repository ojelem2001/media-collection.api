using AutoMapper;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class SeriesInfoProfile : Profile
{
    public SeriesInfoProfile()
    {
        CreateMap<SeriesInfoDbo, SeriesInfo>();
        CreateMap<SeriesInfo, SeriesInfoDbo>();
    }
}
