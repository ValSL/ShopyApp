using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Repositories;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductsByPage;

public class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, OneOf<GetProductsByPageResult, List<Error>>>
{
	private readonly IProductRepository _productRepoditory;

	public GetProductsByPageQueryHandler(IProductRepository productRepository)
	{
		_productRepoditory = productRepository;
	}

	public async Task<OneOf<GetProductsByPageResult, List<Error>>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
		var products = _productRepoditory.GetProductsByPage(request.PageNumber, request.PageSize);
		var productsCount = _productRepoditory.GetProducts().Count;
		if (products is null)
		{
			return new List<Error> { ErrorsProducts.ProductsFetchingError };
		}

		return new GetProductsByPageResult(products, productsCount);
	}
}
