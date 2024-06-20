using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EventManagementSystem.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> RegisterAdminAsync(User user, decimal paymentAmount, string certificationDocuments)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUserAsync(User user, string role)
        {
            user.Role = role;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task RegisterUserAsync(User user, object role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        // Other user service methods...
    }
}
