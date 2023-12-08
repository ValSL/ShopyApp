using Microsoft.AspNetCore.Builder;
using ShopyApp.Models;
using ShopyApp.Application.Services.Authentication;
using ShopyApp.Contracts.Authentication;

namespace ShopyApp.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/auth");
            {
                group.MapPost("register", Register);
                group.MapPost("login", Login);
            }
        }

        private static IResult Register(RegisterRequest request, IAuthenticationService authenticationService)
        {
            AuthenticationResult authResult = authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            AuthResposne response = new AuthResposne(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
            
            return Results.Ok(response);
        }

        private static IResult Login(LoginRequest request, IAuthenticationService authenticationService)
        {
            var authResult = authenticationService.Login(request.Email, request.Password);
            var response = new AuthResposne(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

            return Results.Ok(response);
        }
    }
}
