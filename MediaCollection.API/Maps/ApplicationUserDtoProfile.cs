using AutoMapper;
using MediaCollection.API.Models.User;
using MediaCollection.Core.Models.User;
using MediaCollection.Data.Models.User;

namespace MediaCollection.Data.Maps;
 
public class ApplicationUserDtoProfile : Profile
{
    public ApplicationUserDtoProfile()
    {
        CreateMap<ApplicationUserDto, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserDto>();
    }
}
