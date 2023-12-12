using ShopyApp.Database;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Products.Repositories;

public class ProductRepository : IProducRepository
{
    private readonly AppDbContext _dbContext;
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Product? GetProductById(int id)
    {
        return _dbContext.Products.SingleOrDefault(item => item.ProductId == id);
    }

    public List<Product>? GetProducts()
    {
        return _dbContext.Products.ToList();
    }
}
