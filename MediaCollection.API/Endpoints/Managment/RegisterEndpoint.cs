using FastEndpoints;
using MediaCollection.API.Models.Auth;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Auth;
using MediaCollection.Core.Models.User;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.Auth;

public class RegisterEndpoint(IUserService authService, IMapper mapper) : Endpoint<UserRegisterRequestDto, UserRegisterResponseDto>
{
    public override void Configure()
    {
        Post("/api/users/register");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "User registration";
            s.ExampleRequest = new UserRegisterRequestDto { Name = "John Doe", Login = "user@post.com", Password = "Qwerty1" };
            s.ResponseExamples[200] = new AuthResponseDto { };
            s.Responses[200] = "The user is registered";
            s.Responses[403] = "forbidden response description goes here";
        });
    }

    public override async Task HandleAsync(UserRegisterRequestDto requestDto, CancellationToken cancellationToken)
    {
        var request = mapper.Map<UserRegisterRequestDto, UserRegisterRequest>(requestDto);
        var response = await authService.RegisterAsync(request, cancellationToken);
        await Send.OkAsync(mapper.Map<ApplicationUser, UserRegisterResponseDto>(response), cancellation: cancellationToken);
    }
}