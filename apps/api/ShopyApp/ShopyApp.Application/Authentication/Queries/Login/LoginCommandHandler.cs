using MediatR;
using OneOf;
using ShopyApp.Application.Common.Errors;
using ShopyApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyApp.Application.Common.Interfaces.Authentication;
using ShopyApp.Domain.Entities;

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
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {

                return new InvalidCredentialsError();
            }

            if (user.Password != request.Password)
            {
                return new InvalidCredentialsError();
            }

            string token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
