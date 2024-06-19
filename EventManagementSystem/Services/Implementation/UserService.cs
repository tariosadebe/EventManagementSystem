using System;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;

namespace EventManagementSystem.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAdminAsync(User user, decimal paymentAmount, string certificationDocuments)
        {
            if (paymentAmount < 50000)
            {
                throw new Exception("Insufficient payment for admin registration.");
            }

            user.IsAdmin = true;
            user.IsCertifiedAdmin = !string.IsNullOrEmpty(certificationDocuments);
            user.CertificationDocuments = certificationDocuments;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Other user service methods...
    }
}
