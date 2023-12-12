using ShopyApp.Common.Errors;

namespace ShopyApp.Features.Products.Errors
{
    public static class ErrorsProducts
    {
        public static Error ProductDoesNotExistsError => new("Products.DoesNotExists", StatusCodes.Status404NotFound, "Product with given ID doesn't exists.");
        public static Error ProductsFetchingError => new("Products.Fetching", StatusCodes.Status400BadRequest, "An error occured while fetching data from database.");
    }
}
