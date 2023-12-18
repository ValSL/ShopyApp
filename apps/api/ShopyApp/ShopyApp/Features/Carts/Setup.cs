using ShopyApp.Features.Carts.Repositories;
using ShopyApp.Features.Products.Repositories;

namespace ShopyApp.Features.Carts;

public static class Setup
{
    public static IServiceCollection AddCartFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICartRepository, CartRepository>();
        return serviceCollection;
    }
}