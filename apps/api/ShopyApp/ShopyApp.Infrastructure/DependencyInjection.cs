using Microsoft.Extensions.DependencyInjection;
using ShopyApp.Application;
using ShopyApp.Application.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return serviceCollection;
        }
    }
}
