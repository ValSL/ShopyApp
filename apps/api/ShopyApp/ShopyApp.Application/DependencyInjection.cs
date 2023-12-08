using Microsoft.Extensions.DependencyInjection;
using ShopyApp.Application.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
            return serviceCollection;
        }
    }
}
