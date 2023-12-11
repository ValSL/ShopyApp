using FluentValidation;
using ShopyApp.Features.Authentication.UseCases.Commands.Register;

namespace ShopyApp.Features.Authentication.UseCases.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
