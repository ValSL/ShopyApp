using MediatR;
using OneOf;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Carts.UseCases.Commands.AddToCardCommand;

public record AddToCartCommand(int UserId, int ProductId) : IRequest<OneOf<AddToCartResult, List<Error>>>;