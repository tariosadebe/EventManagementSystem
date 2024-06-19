// UserService.cs

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

        public async Task<User> RegisterAdminAsync(string username, string password, string identityDocument)
        {
            // Check if the user has paid the registration fee
            bool hasPaidRegistrationFee = await CheckPayment(username);

            if (!hasPaidRegistrationFee)
            {
                throw new Exception("User has not paid the registration fee.");
            }

            // Create user logic here (not shown for brevity)
            // Assuming User model has properties like Username, Password, IdentityDocument

            // Save user to database (not shown for brevity)
            var newUser = new User
            {
                Username = username,
                Password = password,
                IdentityDocument = identityDocument,
                IsAdmin = true  // Assuming a property to mark user as admin
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public Task<bool> RegisterAdminAsync(User user, decimal paymentAmount, string certificationDocuments)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> CheckPayment(string username)
        {
            // Logic to check if user has paid registration fee (not implemented here)
            // Example: Check payment status in a payment service or database

            // For demonstration, return true if user has paid (not implemented)
            return true;
        }
    }
}
