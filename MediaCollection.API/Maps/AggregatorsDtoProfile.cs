using AutoMapper;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class AggregatorsDtoProfile : Profile
{
    public AggregatorsDtoProfile()
    {
        CreateMap<AggregatorsDto, Aggregators>();
        CreateMap<Aggregators, AggregatorsDto>();
    }
}
