using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Data
{
    public interface INotificationRepository
    {
        Task<List<EmailNotification>> GetPendingEmailNotifications();
        Task<List<SmsNotification>> GetPendingSmsNotifications();
        Task UpdateEmailNotification(EmailNotification emailNotification);
        Task UpdateSmsNotification(SmsNotification smsNotification);
    }
}
