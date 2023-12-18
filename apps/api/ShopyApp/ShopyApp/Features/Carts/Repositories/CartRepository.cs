using Microsoft.EntityFrameworkCore;
using ShopyApp.Database;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Features.Carts.Models;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Carts.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _dbContext;
    public CartRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddToCart(int userId, int productId)
    {
        var cart = await GetOrCreateUserCart(userId);
        var product = _dbContext.Products.Where(item => item.ProductId.Equals(productId)).SingleOrDefault();

        if (_dbContext.CartItems
                        .Where(item => item.ParentCartId == cart.CartId && item.ProductId == product.ProductId)
                        .SingleOrDefault() is CartItem cartItem)
        {
            _dbContext.CartItems
                        .Where(item => item.CartItemId == cartItem.CartItemId)
                        .ExecuteUpdate(setter => setter
                            .SetProperty(item => item.ProductAmount, item => item.ProductAmount + 1)
                            .SetProperty(item => item.TotalPrice, item => item.TotalPrice + product.Price));
        }
        else
        {
            var newCartItem = new CartItem
            {
                ParentCartId = cart.CartId,
                ProductId = product.ProductId,
                ProductAmount = 1,
                TotalPrice = product.Price
            };
            await _dbContext.CartItems.AddAsync(newCartItem);
            await _dbContext.SaveChangesAsync();
        }
    }

    public Cart GetCartById(int id)
    {
        throw new NotImplementedException();
    }

    private async Task<Cart> GetOrCreateUserCart(int userId)
    {
        if (_dbContext.Carts.Where(item => item.CartOwner.Equals(userId)).SingleOrDefault() is Cart cart)
        {
            return cart;
        }
        var result = await _dbContext.Carts.AddAsync(new Cart { CartOwner = userId })!;
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
}
