using Microsoft.EntityFrameworkCore;
using ShopyApp.Database;
using ShopyApp.Features.Products.Models;
using Point = (int x, int y);

namespace ShopyApp.Features.Products.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PostgreSqlDbContext _dbContext;
    private readonly MySqlDbContext _mySqlDbContext;

    public ProductRepository(PostgreSqlDbContext dbContext, MySqlDbContext mySqlDbContext)
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

    public IQueryable<Product> GetProducts()
    {
        return _dbContext.Products.AsNoTracking();
    }

    public List<Product>? GetProductsByPage(int pageNumber, int pageSize, string query)
    {
        IQueryable<Product> products;
        if (query != null)
        {
            products = _dbContext.Products
            .AsNoTracking()
            .OrderBy(item => item.ProductId)
            .Where(item => item.Title.Contains(query))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        }
        else
        {
            products = _dbContext.Products
            .AsNoTracking()
            .OrderBy(item => item.ProductId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        }

        return [.. products];
    }
}
