using ShopyApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MapsterMapper;
using ShopyApp.Application.Authentication.Queries.Login;
using ShopyApp.Features.Authentication.UseCases.Commands.Register;
using FluentValidation;
using Carter;

namespace ShopyApp.Features.Authentication
{
    public class AuthController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auth");
            {
                group.MapPost("register", Register);
                group.MapPost("login", Login);
            }
        }

        public async Task<IResult> Register(IMediator mediator, IMapper mapper, IValidator<RegisterCommand> validator, RegisterRequest request)
        {
            var registerCommand = mapper.Map<RegisterCommand>(request);
            var result = await validator.ValidateAsync(registerCommand);
            if (!result.IsValid)
            {
                return Results.ValidationProblem(result.ToDictionary());
            }

            var authResult = await mediator.Send(registerCommand);

            return authResult.Match(
                result => Results.Ok(mapper.Map<AuthResposne>(result)),
                error => Results.Problem(detail: error.Message, statusCode: error.StatusCode));
        }

        public async Task<IResult> Login(IMediator mediator, IMapper mapper, IValidator<LoginQuery> validator, LoginRequest request)
        {
            var loginQuery = mapper.Map<LoginQuery>(request);
            var validationResult = await validator.ValidateAsync(loginQuery);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            
            var authResult = await mediator.Send(loginQuery);

            return authResult.Match(
                result => Results.Ok(mapper.Map<AuthResposne>(result)),
                error => Results.Problem(detail: error.Message, statusCode: error.StatusCode));
        }
    }
}
