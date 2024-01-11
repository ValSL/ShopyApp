using Microsoft.EntityFrameworkCore;
using ShopyApp.Database;
using ShopyApp.Features.Products.Models;
using Point = (int x, int y);

namespace ShopyApp.Features.Products.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    private readonly MySqlDbContext _mySqlDbContext;

    public ProductRepository(AppDbContext dbContext, MySqlDbContext mySqlDbContext)
    {
        _dbContext = dbContext;
        _mySqlDbContext = mySqlDbContext;
    }

    public async Task CreateProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public Product? GetProductById(int id)
    {
        return _dbContext.Products.SingleOrDefault(item => item.ProductId == id);
    }

    public List<Product> GetProducts()
    {
        return _dbContext.Products.AsNoTracking().ToList();
    }

    public List<Product>? GetProductsByPage(int pageNumber, int pageSize)
    {
        var (x, y) = new Point(1, 2);
        IQueryable<Product> products = _dbContext.Products
            .AsNoTracking()
            .OrderBy(item => item.ProductId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        return [.. products];
    }
}
