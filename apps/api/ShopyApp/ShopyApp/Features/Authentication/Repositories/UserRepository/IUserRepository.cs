using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyApp.Features.Authentication.Models;

namespace ShopyApp.Features.Authentication.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        Task<User> AddUserAsync(User user);
    }
}
