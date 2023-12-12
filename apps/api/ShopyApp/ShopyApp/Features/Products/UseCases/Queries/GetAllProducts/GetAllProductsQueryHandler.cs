using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Contracts;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.Repositories;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, OneOf<GetAllProductsResult, List<Error>>>
{
    private readonly IProducRepository _productsRepository;
    public GetAllProductsQueryHandler(IProducRepository productsRepository)
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
        return new GetAllProductsResult(products.ToList());
    }

    
}

