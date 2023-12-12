using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Carts.Models;

namespace ShopyApp.Features.Authentication.Models
{

    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
