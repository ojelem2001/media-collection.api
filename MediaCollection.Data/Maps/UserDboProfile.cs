using AutoMapper;
using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.User;
using MediaCollection.Data.Models.User;

namespace MediaCollection.Data.Maps;
 
public class UserDboProfile : Profile
{
    public UserDboProfile()
    {
        CreateMap<ApplicationUserDbo, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserDbo>();
        CreateMap<UserRegisterRequest, ApplicationUserDbo>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => false));//by default user inactive
       
        CreateMap<RefreshToken, RefreshTokenDbo>()
            .ForMember(dest => dest.UserGuid, opt => opt.MapFrom(src => src.User.Guid))
            .ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore User than create token
        ;
        CreateMap<RefreshTokenDbo, RefreshToken>();
    }
}
