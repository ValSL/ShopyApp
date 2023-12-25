using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Products.Errors;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.Repositories;
using ShopyApp.Features.Products.UseCases.Commands.CreateProductCommand;

namespace ShopyApp;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, OneOf<CreateProductResult, List<Error>>>
{
    private readonly IProductRepository _productRepository;
    private readonly IImageUploadService _uploadService;
    public CreateProductCommandHandler(IProductRepository productRepository, IImageUploadService uploadService)
    {
        _productRepository = productRepository;
        _uploadService = uploadService;
    }

    public async Task<OneOf<CreateProductResult, List<Error>>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageUrl = await _uploadService.UploadSingleFile(request.Image);
        var product = new Product
        {
            Title = request.Title,
            Price = int.Parse(request.Price),
            ImageUrl = imageUrl,
            OwnerId = request.OwnerId
        };

        await _productRepository.CreateProduct(product);
        return new CreateProductResult(product);
    }
}
