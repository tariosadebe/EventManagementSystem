using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementSystem.Models;
using EventManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Data
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmailNotification>> GetPendingEmailNotifications()
        {
            return await _context.EmailNotifications
                .Where(e => e.Status == NotificationStatus.Pending)
                .ToListAsync();
        }

        public async Task<List<SmsNotification>> GetPendingSmsNotifications()
        {
            return await _context.SmsNotifications
                .Where(s => s.Status == NotificationStatus.Pending)
                .ToListAsync();
        }

        public async Task UpdateEmailNotification(EmailNotification emailNotification)
        {
            _context.EmailNotifications.Update(emailNotification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSmsNotification(SmsNotification smsNotification)
        {
            _context.SmsNotifications.Update(smsNotification);
            await _context.SaveChangesAsync();
        }
    }
}
