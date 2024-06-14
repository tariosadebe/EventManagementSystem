using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface INotificationService
    {
        Task ProcessPendingNotificationsAsync();
    }
}
