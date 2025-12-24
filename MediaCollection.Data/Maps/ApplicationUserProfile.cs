using AutoMapper;
using MediaCollection.Core.Models.User;
using MediaCollection.Data.Models.User;

namespace MediaCollection.Data.Maps;
 
public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<ApplicationUserDbo, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserDbo>();
    }
}
