using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> RegisterAdminAsync(User user, decimal paymentAmount, string certificationDocuments)
        {
            // Perform necessary checks and validations
            // Assuming payment processing and certification document verification are done here

            // Mark user as admin
            user.Role = "Admin";
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> RegisterUserAsync(User user, string role)
        {
            user.Role = role;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task RegisterUserAsync(User user, object role)
        {
            if (role is string stringRole)
            {
                await RegisterUserAsync(user, stringRole);
            }
            else
            {
                throw new NotImplementedException("Role type is not supported.");
            }
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Other user service methods...
    }
}
