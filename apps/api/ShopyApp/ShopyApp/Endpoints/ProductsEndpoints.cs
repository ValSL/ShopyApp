using Microsoft.EntityFrameworkCore;
using ShopyApp.Models;

namespace ShopyApp.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/products");
            {
                group.MapGet("", GetAllProducts);
            }
        }

        private static async Task<IResult> GetAllProducts(AppDbContext db)
        {
            List<Product> list = await db.Products.ToListAsync();
            return Results.Ok(list);
        }
    }
}
