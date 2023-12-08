using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopyApp.Application;
using ShopyApp.Application.Common.Interfaces.Authentication;
using ShopyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
        {
            serviceCollection.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));
            serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
    }
}
