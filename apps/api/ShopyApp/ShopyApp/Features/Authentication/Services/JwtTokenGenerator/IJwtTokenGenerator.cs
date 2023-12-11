
using ShopyApp.Features.Authentication.Models;

namespace ShopyApp.Features.Authentication.Services.JwtTokenGenerator;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
