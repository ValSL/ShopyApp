using System;
using System.Collections.Generic;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Carts.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }
    public int? ParentCartId { get; set; }
    public int? ProductId { get; set; }
    public int? ProductAmount { get; set; }
    public int? TotalPrice { get; set; }
    public virtual Cart? ParentCart { get; set; }
    public virtual Product? Product { get; set; }
}
