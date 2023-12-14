using ShopyApp.Features.Products.Repositories;

namespace ShopyApp;

public static class Setup
{
    public static IServiceCollection AddProductsFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IImageUploadService, CloudinaryImageUploadService>();
        return serviceCollection;
    }
}