using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAdminAsync(User user, decimal paymentAmount, string certificationDocuments);
        // Other user service methods...
    }
}
