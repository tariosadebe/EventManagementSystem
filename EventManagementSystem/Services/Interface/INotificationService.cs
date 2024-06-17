using EventManagementSystem.Models;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Notification = EventManagementSystem.Models.Notification;

namespace EventManagementSystem.Services
{
    public interface INotificationService
    {
        Task ProcessPendingNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int id);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
    }
}
