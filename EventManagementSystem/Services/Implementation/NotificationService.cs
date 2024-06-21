using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            var pendingNotifications = await _context.Notifications
                .Where(n => !n.IsSent)
                .ToListAsync();

            foreach (var notification in pendingNotifications)
            {
                // Implement the logic to send notification (e.g., via email or SMS)
                notification.IsSent = true;
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
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notificationToDelete = await _context.Notifications.FindAsync(id);
            if (notificationToDelete != null)
            {
                _context.Notifications.Remove(notificationToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
