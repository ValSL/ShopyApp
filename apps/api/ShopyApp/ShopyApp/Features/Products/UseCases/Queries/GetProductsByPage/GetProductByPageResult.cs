using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Products.UseCases.Queries.GetProductsByPage;

public record GetProductsByPageResult(List<Product> Products, int ProductsCount);