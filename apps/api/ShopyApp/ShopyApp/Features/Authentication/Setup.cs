using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using ShopyApp.Features.Authentication.Repositories.UserRepository;
using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;

public static class Setup
{
    public static IServiceCollection AddAuthFeatures(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddAuthentication().AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["JwtSettings:Secret"]!)),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        });
        serviceCollection.AddAuthorization();
        serviceCollection.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));
        serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Setup).Assembly));
        //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        return serviceCollection;
    }
}