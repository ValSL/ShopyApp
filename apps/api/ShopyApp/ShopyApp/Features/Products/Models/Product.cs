using System;
using System.Collections.Generic;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Features.Carts.Models;

namespace ShopyApp.Features.Products.Models;

public partial class Product
{
    public int ProductId { get; set; }
    public string Title { get; set; } = null!;
    public int Price { get; set; }
    public string? ImageUrl { get; set; }
    public int? OwnerId { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public virtual User? Owner { get; set; }
}
