using MediatR;
using OneOf;
using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.UseCases.Commands.CreateProductCommand;

public record CreateProductCommand(
    string Title,
    string Price,
    IFormFile Image,
    int? OwnerId
): IRequest<OneOf<CreateProductResult, List<Error>>>;
