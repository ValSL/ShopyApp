using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Carts.Repositories;
using ShopyApp.Features.Carts.UseCases.Commands.AddToCardCommand;

namespace ShopyApp.Features.Carts.UseCases.Commands.CreateNewCartCommand;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, OneOf<AddToCartResult, List<Error>>>
{
    private readonly ICartRepository _cartRepository;

    public AddToCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<OneOf<AddToCartResult, List<Error>>> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.AddToCart(request.UserId, request.ProductId);
        return new AddToCartResult(1);
    }
}
