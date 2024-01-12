using MediatR;
using OneOf;
using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductsByPage;
public record GetProductsByPageQuery(int PageNumber, int PageSize, string Query): IRequest<OneOf<GetProductsByPageResult, List<Error>>>;