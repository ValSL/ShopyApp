using System;
using System.Collections.Generic;

namespace ShopyApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public int Price { get; set; }

    public string? ImageUrl { get; set; }

    public int? OwnerId { get; set; }

    public virtual User? Owner { get; set; }
}
