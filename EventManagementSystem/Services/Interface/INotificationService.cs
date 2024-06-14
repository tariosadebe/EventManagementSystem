using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface INotificationService
    {
        Task ProcessPendingNotificationsAsync(); // Ensure this method is defined
        Task ProcessEmailNotifications();
        Task ProcessSmsNotifications();
    }
}
