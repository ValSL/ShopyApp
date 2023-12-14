using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Products.UseCases.Queries.GetAllProducts;

public record GetAllProductsResult(List<Product> Products);

