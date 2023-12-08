using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            //serviceCollection.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            //serviceCollection.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            serviceCollection.AddMediatR(typeof(DependencyInjection).Assembly);
            return serviceCollection;
        }
    }
}
