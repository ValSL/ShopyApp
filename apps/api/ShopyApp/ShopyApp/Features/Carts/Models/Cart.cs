using System;
using System.Collections.Generic;
using ShopyApp.Features.Authentication.Models;

namespace ShopyApp.Features.Carts.Models;

public partial class Cart
{
    public int CartId { get; set; }
    public int? CartOwner { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public virtual User? CartOwnerNavigation { get; set; }
}
