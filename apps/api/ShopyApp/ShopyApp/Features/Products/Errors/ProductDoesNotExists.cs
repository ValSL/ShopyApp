using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.Errors;

public class ProductDoesNotExists : IError
{
    public int StatusCode { get ; set; } = StatusCodes.Status404NotFound;
    public string Message { get ; set; } = "Product with given ID doesn't exists";
}
