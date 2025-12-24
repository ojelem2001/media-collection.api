using AutoMapper;
using MediaCollection.Core.Models.Media;
using MediaCollection.Data.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class AggregatorsProfile : Profile
{
    public AggregatorsProfile()
    {
        CreateMap<AggregatorsDbo, Aggregators>();
        CreateMap<Aggregators, AggregatorsDbo>();
    }
}
