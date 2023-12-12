using FluentValidation;
using ShopyApp.Application.Authentication.Queries.Login;

public class LoginCommandValidator : AbstractValidator<LoginQuery>
{
    public LoginCommandValidator()
    {
        RuleFor(query => query.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(query => query.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}