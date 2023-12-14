using FluentValidation;
using ShopyApp.Features.Products.UseCases.Commands.CreateProductCommand;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(item => item.Title).NotNull().MaximumLength(255);
        RuleFor(item => item.Image).NotNull();
        RuleFor(item => item.OwnerId).NotNull();
        RuleFor(item => item.Price).NotNull();
    }
}