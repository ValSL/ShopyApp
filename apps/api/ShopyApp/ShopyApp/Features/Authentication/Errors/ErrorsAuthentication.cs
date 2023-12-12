using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Authentication.Errors
{
    public static class ErrorsAuthentication
    {
        public static Error DuplicateEmailError => new("Auth.DuplicateEmail", StatusCodes.Status409Conflict, "User with given email already exists.");
        public static Error InvalidCredentialsError => new("Auth.InvalidCredentials", StatusCodes.Status400BadRequest, "Invalid credentials.");
    }
}
