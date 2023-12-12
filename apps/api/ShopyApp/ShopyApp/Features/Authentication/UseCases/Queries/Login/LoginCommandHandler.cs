using MediatR;
using OneOf;
using ShopyApp.Application.Common.Errors;
using ShopyApp.Application.Common;
using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;
using ShopyApp.Features.Authentication.Repositories.UserRepository;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Common.Errors;
using BCrypt.Net;

namespace ShopyApp.Application.Authentication.Queries.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginQuery, OneOf<AuthenticationResult, IError>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<OneOf<AuthenticationResult, IError>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // заглушка

            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return new InvalidCredentialsError();
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new InvalidCredentialsError();
            }

            string token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user.FirstName, user.LastName, user.Email, token);

        }
    }
}
