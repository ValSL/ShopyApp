namespace ShopyApp.Application;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid id, string firstname, string lastname);
}
