using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Repositories;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, OneOf<GetProductByIdResult, List<Error>>>
    {
        private readonly IProductRepository _productsRepository;
        public GetProductByIdQueryHandler(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<OneOf<GetProductByIdResult, List<Error>>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await Task.Run(() => _productsRepository.GetProductById(request.Id));
            if (product is null)
            {
                return new List<Error> { ErrorsProducts.ProductDoesNotExistsError };

            }

            return new GetProductByIdResult(product);
        }
    }
}
