using MediatR;
using OneOf;
using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id): IRequest<OneOf<GetProductByIdResult, List<Error>>>;
}
