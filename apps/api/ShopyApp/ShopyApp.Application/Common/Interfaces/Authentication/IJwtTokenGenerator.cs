using ShopyApp.Domain.Entities;

namespace ShopyApp.Application;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
