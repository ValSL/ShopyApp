using MediatR;
using OneOf;
using ShopyApp.Application.Common.Errors;
using ShopyApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;
using ShopyApp.Features.Authentication.Repositories.UserRepository;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Authentication.UseCases.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<AuthenticationResult, IError>>
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<OneOf<AuthenticationResult, IError>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.Email) != null)
            {
                return new DuplicateEmailError();
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
