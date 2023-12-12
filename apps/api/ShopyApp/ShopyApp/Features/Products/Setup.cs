using ShopyApp.Features.Products.Repositories;

namespace ShopyApp;

public static class Setup
{
    public static IServiceCollection AddProductsFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProducRepository, ProductRepository>();
        return serviceCollection;
    }
}