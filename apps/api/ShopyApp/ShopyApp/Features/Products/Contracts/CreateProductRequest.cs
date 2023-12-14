using ShopyApp.Features.Products.Models;

namespace ShopyApp;

public record CreateProductRequest(
    string Title,
    string Price
    // IFormFile Image
);
