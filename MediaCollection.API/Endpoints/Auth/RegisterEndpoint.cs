using FastEndpoints;
using MediaCollection.API.Models.Auth;
using MediaCollection.Core.Abstract;
using MediaCollection.Core.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;
using IMapper = AutoMapper.IMapper;

namespace MediaCollection.API.Endpoints.Auth;

public class RegisterEndpoint(IUserService authService, IMapper mapper) : Endpoint<RegisterRequest, AuthResponseDto>
{
    public override void Configure()
    {
        Post("/api/users/register");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "User registration";
            s.ExampleRequest = new RegisterRequest { Email="user@post.com", Password="Qwerty1" };
            s.ResponseExamples[200] = new AuthResponseDto { };
            s.Responses[200] = "The user is registered";
            s.Responses[403] = "forbidden response description goes here";
        });
    }

    public override async Task HandleAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var response = await authService.RegisterAsync(request.Email, request.Password, cancellationToken);
        await Send.OkAsync(mapper.Map<AuthResponse, AuthResponseDto>(response), cancellation: cancellationToken);
    }
}