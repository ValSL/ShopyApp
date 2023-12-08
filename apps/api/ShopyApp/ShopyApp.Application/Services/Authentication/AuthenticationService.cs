using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "firstname", "lastname", email, "token");
        }

        public AuthenticationResult Register(string firstname, string lastname, string email, string password)
        {
            Guid guid = Guid.NewGuid();
            string token = _jwtTokenGenerator.GenerateToken(guid, firstname, lastname);
            return new AuthenticationResult(guid, firstname, lastname, email, token);
        }
    }
}
