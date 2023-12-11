using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopyApp.Features.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ShopyApp.Features.Authentication.Services.JwtTokenGenerator;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;


    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret!));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            audience: _jwtSettings.Audience,
            issuer: _jwtSettings.Issuer,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiringMinutes),
            claims: claims,
            signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
