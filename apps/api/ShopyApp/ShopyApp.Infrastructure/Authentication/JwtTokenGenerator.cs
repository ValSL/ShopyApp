using Microsoft.IdentityModel.Tokens;
using ShopyApp.Application;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ShopyApp.Infrastructure;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid id, string firstname, string lastname)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("quvnfofmvjvhqnvcnhfueirmghgjaadasdasdqweqweczczxczxc"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: "ShopyApp", expires: DateTime.UtcNow.AddMinutes(60), claims: claims, signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
