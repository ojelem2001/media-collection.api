using FastEndpoints;
using MediaCollection.API.Models.Auth;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.Auth;

public class LoginEndpoint(IUserService authService, IMapper mapper) :  Endpoint<LoginRequest, AuthResponseDto>
{

    public override void Configure()
    {
        Post("/api/users/auth");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "User authentication method";
            s.Responses[200] = "Successful user authentication";
        });
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var response = authService.Login(request.Email, request.Password, cancellationToken);
        await Send.OkAsync(mapper.Map<AuthResponse, AuthResponseDto>(response), cancellation: cancellationToken);
    }
}