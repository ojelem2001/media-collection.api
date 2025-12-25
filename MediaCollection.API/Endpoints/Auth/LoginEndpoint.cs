using FastEndpoints;
using MediaCollection.API.Models.Auth;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.Auth;

public class LoginEndpoint(IUserService authService, IMapper mapper) :  Endpoint<UserLoginRequestDto, AuthResponseDto>
{

    public override void Configure()
    {
        Post("/api/users/auth");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "User authentication method";
            s.ExampleRequest = new UserLoginRequestDto { Login = "user@post.com", Password = "Qwerty1" };
            s.Responses[200] = "Successful user authentication";
        });
    }

    public override async Task HandleAsync(UserLoginRequestDto request, CancellationToken cancellationToken)
    {
        var response = await authService.AuthenticateAsync(mapper.Map<UserLoginRequestDto, UserLoginRequest>(request), cancellationToken);
        await Send.OkAsync(mapper.Map<RefreshToken, AuthResponseDto>(response), cancellation: cancellationToken);
    }
}