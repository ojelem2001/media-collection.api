using AutoMapper;
using MediaCollection.API.Models.Auth;
using MediaCollection.API.Models.User;
using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.User;

namespace MediaCollection.Data.Maps;
 
public class UserDtoProfile : Profile
{
    public UserDtoProfile()
    {
        CreateMap<RefreshToken, AuthResponseDto>();

        CreateMap<UserRegisterRequestDto, UserRegisterRequest>();

        CreateMap<UserLoginRequestDto, UserLoginRequest>();

        CreateMap<ApplicationUserDto, ApplicationUser>();

        CreateMap<ApplicationUser, UserRegisterResponseDto>();
    }
}
