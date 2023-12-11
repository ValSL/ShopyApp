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
            await Task.CompletedTask; // заглушка
            System.Console.WriteLine("RegisterCommandHandler");
            if (_userRepository.GetUserByEmail(request.Email) != null)
            {
                return new DuplicateEmailError();
            }

            User user = new User()
            {
                // FirstName = request.FirstName,
                // LastName = request.LastName,
                Username = request.FirstName,
                Email = request.Email,
                PasswordHash = request.Password
            };

            _userRepository.AddUser(user);

            string token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(token);
        }
    }
}
