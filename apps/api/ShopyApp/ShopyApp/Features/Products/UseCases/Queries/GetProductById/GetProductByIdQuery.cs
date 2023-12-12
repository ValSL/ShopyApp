using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Contracts;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id): IRequest<OneOf<GetProductByIdResult, List<Error>>>;
}
