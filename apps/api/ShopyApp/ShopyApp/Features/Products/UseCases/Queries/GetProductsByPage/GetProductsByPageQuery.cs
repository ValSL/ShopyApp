using MediatR;
using OneOf;
using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductsByPage;
public class GetProductsByPageQuery: IRequest<OneOf<GetProductsByPageResult, List<Error>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Query { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
}