using MediatR;
using OneOf;
using ShopyApp.Application.Common;
using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;
using ShopyApp.Features.Authentication.Repositories.UserRepository;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Common.Errors;
using ShopyApp.Features.Authentication.Errors;

namespace ShopyApp.Features.Authentication.UseCases.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<AuthenticationResult, List<Error>>>
    {
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OneOf<AuthenticationResult, List<Error>>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.Email) != null)
            {
                return new List<Error> { ErrorsAuthentication.DuplicateEmailError };
            }

            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            var addedUser = await _userRepository.AddUserAsync(user);

            return new AuthenticationResult(addedUser.FirstName, addedUser.LastName, addedUser.Email, string.Empty);
        }
    }
}
