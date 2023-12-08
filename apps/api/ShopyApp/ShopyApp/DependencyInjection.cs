﻿using ShopyApp.Common.Mapping;

namespace ShopyApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMapping();
            return services;
        }
    }
}
