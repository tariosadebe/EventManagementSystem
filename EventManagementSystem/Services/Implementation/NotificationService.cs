using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ApplicationDbContext context, ILogger<NotificationService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task ProcessPendingNotificationsAsync()
        {
            // Implementation for processing pending notifications
            var pendingNotifications = await _context.Notifications
                .Where(n => !n.IsSent)
                .ToListAsync();

            foreach (var notification in pendingNotifications)
            {
                // Process and send the notification
                // Example: _emailService.SendEmailAsync(notification.Email, notification.Subject, notification.Message);

                notification.IsSent = true;
                _context.Notifications.Update(notification);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            var existingNotification = await _context.Notifications.FindAsync(notification.Id);
            if (existingNotification == null)
            {
                throw new NotImplementedException($"Notification with ID {notification.Id} not found.");
            }

            existingNotification.Message = notification.Message;
            existingNotification.Email = notification.Email;
            existingNotification.Subject = notification.Subject;
            existingNotification.IsSent = notification.IsSent;

            _context.Notifications.Update(existingNotification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                throw new NotImplementedException($"Notification with ID {id} not found.");
            }

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
    }
}
