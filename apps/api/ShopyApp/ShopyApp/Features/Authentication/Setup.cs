using System.IdentityModel.Tokens.Jwt;
using MediatR;
using ShopyApp.Features.Authentication.Repositories.UserRepository;
using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;

public static class Setup
{
    public static IServiceCollection AddAuthFeatures(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));
        serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddMediatR(typeof(Setup).Assembly); 
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        return serviceCollection;
    }
}