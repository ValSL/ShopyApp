using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyApp.Features.Carts.Contracts;
using ShopyApp.Features.Carts.UseCases.Commands.AddToCardCommand;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Carts;

public class Endpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/carts").RequireAuthorization();
        {
            group.MapPut("additem", AddToCart);
        }
    }

    public void AddToCart([FromBody]AddToCartRequest request, HttpContext httpContext, IMediator mediator)
    {
        var command = new AddToCartCommand(int.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!), request.ProductId);
        mediator.Send(command);
    }

}
