using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Products.Repositories;

public interface IProducRepository
{
    List<Product>? GetProducts();
    Product? GetProductById(int id);
}
