using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.UseCases.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<OneOf<GetAllProductsResult, List<Error>>>;