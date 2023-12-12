using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Contracts;
using ShopyApp.Features.Products.Models;

public record GetAllProductsQuery() : IRequest<OneOf<GetAllProductsResult, List<Error>>>;