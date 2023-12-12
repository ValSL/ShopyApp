using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.Errors
{
    public class ProductsFetchingError : IError
    {
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
        public string Message { get; set; } = "An error occured while fetching data from database";
    }
}
