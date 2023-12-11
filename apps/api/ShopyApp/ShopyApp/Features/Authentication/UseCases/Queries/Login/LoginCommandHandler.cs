using MediatR;
using OneOf;
using ShopyApp.Application.Common.Errors;
using ShopyApp.Application.Common;
using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;
using ShopyApp.Features.Authentication.Repositories.UserRepository;
using ShopyApp.Features.Authentication.Models;

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

            if (user.PasswordHash != request.Password)
            {
                return new InvalidCredentialsError();
            }

            string token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(token);
        }
    }
}
