using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopyApp.Database;
using ShopyApp.Features.Authentication.Models;

namespace ShopyApp.Features.Authentication.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        //private static readonly List<User> _users = new();

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var resultUser = await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return resultUser.Entity;
        }

        public User? GetUserByEmail(string email)
        {
            return _appDbContext.Users.AsNoTracking().SingleOrDefault(u => u.Email == email);
        }
    }
}
