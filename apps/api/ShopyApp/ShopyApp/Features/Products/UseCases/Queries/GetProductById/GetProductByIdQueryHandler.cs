using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Contracts;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.Repositories;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, OneOf<GetProductByIdResult, IError>>
    {
        private readonly IProducRepository _productsRepository;
        public GetProductByIdQueryHandler(IProducRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<OneOf<GetProductByIdResult, IError>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await Task.Run(() => _productsRepository.GetProductById(request.Id));
            if (product is null)
            {
                return new ProductDoesNotExists();
            }

            return new GetProductByIdResult(product);
        }
    }
}
