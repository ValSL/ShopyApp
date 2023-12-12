using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Products.Contracts;

public record GetAllProductsResult(List<Product> Products);
    
