using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopyApp.Models;

namespace ShopyApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(AppDbContext db)
        {
            List<Product> list = await db.Products.ToListAsync();
            return Ok(list);
        }
    }
}
