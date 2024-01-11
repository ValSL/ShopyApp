using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.Repositories;
using ShopyApp.Features.Products.UseCases.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, OneOf<GetAllProductsResult, List<Error>>>
{
    private readonly IProductRepository _productsRepository;
    public GetAllProductsQueryHandler(IProductRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<OneOf<GetAllProductsResult, List<Error>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var products = _productsRepository.GetProducts();
        if (products is null)
        {
            return new List<Error> { ErrorsProducts.ProductsFetchingError };
        }
        return new GetAllProductsResult(products.Where(x => x.ProductId <= 9).ToList());
    }

    
}

