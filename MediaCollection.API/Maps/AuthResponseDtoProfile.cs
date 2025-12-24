using AutoMapper;
using MediaCollection.API.Models.Auth;
using MediaCollection.API.Models.Media;
using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.Media;

namespace MediaCollection.Data.Maps;
 
public class AuthResponseDtoProfile : Profile
{
    public AuthResponseDtoProfile()
    {
        CreateMap<AuthResponse, AuthResponseDto>();
    }
}
