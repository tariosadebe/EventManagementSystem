using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> RegisterAdminAsync(User user, decimal paymentAmount, string certificationDocuments);
        Task RegisterUserAsync(User user, object role);
        Task<bool> RegisterUserAsync(User user);
        // Other user service methods...
    }
}
