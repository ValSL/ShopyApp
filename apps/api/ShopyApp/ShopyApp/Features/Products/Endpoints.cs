using Carter;
using FluentValidation;
using MapsterMapper;
using MediatR;
using ShopyApp.Features.Products.Contracts;
using ShopyApp.Features.Products.UseCases.Queries.GetProductById;

public class ProductsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");
        {
            group.MapGet("", GetAllProducts);
            group.MapGet("/{id}", GetProductById);
        }
    }

    public async Task<IResult> GetAllProducts(IMediator mediator, IMapper mapper)
    {

        var getAllProductsResult = await mediator.Send(new GetAllProductsQuery());

        return getAllProductsResult.Match(
            result => Results.Ok(result.Products),
            error => Results.Problem(detail: error.Message, statusCode: error.StatusCode));
    }

    public async Task<IResult> GetProductById([AsParameters]GetProductByIdRequest request, IMediator mediator, IMapper mapper, IValidator<GetProductByIdQuery> validator)
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
            error => Results.Problem(detail: error.Message, statusCode: error.StatusCode));
    }


}