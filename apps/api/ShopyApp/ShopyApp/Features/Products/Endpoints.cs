using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Carter;
using CloudinaryDotNet;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyApp;
using ShopyApp.Features.Products.Contracts;
using ShopyApp.Features.Products.UseCases.Commands.CreateProductCommand;
using ShopyApp.Features.Products.UseCases.Queries.GetProductById;

public class ProductsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");
        {
            group.MapGet("", GetAllProducts);
            group.MapGet("/{id}", GetProductById);
            group.MapPost("/create", CreateProduct).RequireAuthorization();
        }
    }
    public async Task<IResult> CreateProduct(HttpRequest request,HttpContext context, IMediator mediator, IMapper mapper, IValidator<CreateProductCommand> validator)
    {
        // var a = context.User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        // var a = context.User.Claims.First(item => item.Type == JwtRegisteredClaimNames.Sub).Value;

        var claimsIdentity = context.User.Identity as ClaimsIdentity;
        var userName = claimsIdentity?.FindFirst(JwtRegisteredClaimNames.Sub);

        var createProductCommand = new CreateProductCommand(
            request.Form["Title"],
            request.Form["Price"],
            request.Form.Files["Image"],
            int.Parse(context.User.FindFirstValue(JwtRegisteredClaimNames.Sub))
        );
        
        var validationResult = await validator.ValidateAsync(createProductCommand);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var createProductResult = await mediator.Send(createProductCommand);

        return createProductResult.Match(
            result => Results.Created($"/api/products/{result.Product.ProductId}", result.Product),
            errors => ProblemDetailsHelper.ProblemDetails(errors));
    }

    public async Task<IResult> GetAllProducts(IMediator mediator, IMapper mapper)
    {

        var getAllProductsResult = await mediator.Send(new GetAllProductsQuery());

        return getAllProductsResult.Match(
            result => Results.Ok(result.Products),
            errors => ProblemDetailsHelper.ProblemDetails(errors));
    }

    public async Task<IResult> GetProductById([AsParameters] GetProductByIdRequest request, IMediator mediator, IMapper mapper, IValidator<GetProductByIdQuery> validator)
    {
        var getProductByIdQuery = mapper.Map<GetProductByIdQuery>(request);
        var validationResult = await validator.ValidateAsync(getProductByIdQuery);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var getProductByIdResult = await mediator.Send(getProductByIdQuery);

        return getProductByIdResult.Match(
            result => Results.Ok(result.Product),
            errors => ProblemDetailsHelper.ProblemDetails(errors));
    }


}