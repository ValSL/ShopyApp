using ShopyApp.Features.Authentication.Models;
using ShopyApp.Features.Carts.Models;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Carts.Repositories;

public interface ICartRepository
{
    Cart GetCartById(int id);
    Task AddToCart(int userId, int productId);
}