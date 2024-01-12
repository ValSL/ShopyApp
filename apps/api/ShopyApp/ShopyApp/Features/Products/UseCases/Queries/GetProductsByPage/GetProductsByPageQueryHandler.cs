using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.Repositories;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductsByPage;

public class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, OneOf<GetProductsByPageResult, List<Error>>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByPageQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<OneOf<GetProductsByPageResult, List<Error>>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var productsCount = 0;

        IQueryable<Product> products;

        var productsByQuery = _productRepository.GetProducts()
            .OrderBy(item => item.ProductId)
            .Where(item => item.Title.ToLower().Contains(request.Query != null ? request.Query.ToLower() : ""))
            .Where(item => !string.IsNullOrEmpty(request.From) ? item.Price >= int.Parse(request.From) : item.Price >= 0)
            .Where(item => !string.IsNullOrEmpty(request.To) ? item.Price <= int.Parse(request.To) : item.Price <= 1000000000);

        productsCount = productsByQuery.Count();

        products = productsByQuery
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        if (products is null)
        {
            return new List<Error> { ErrorsProducts.ProductsFetchingError };
        }

        return new GetProductsByPageResult([.. products], productsCount);
    }
}
