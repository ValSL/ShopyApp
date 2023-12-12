using FluentValidation;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductById
{
    public class GetProductByIdQueryValidator: AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(item => item.Id)
                .NotEmpty().WithMessage("ID parameter doesn't exist");
        }
    }
}
