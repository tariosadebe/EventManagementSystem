using EventManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int id);
        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
    }
}
