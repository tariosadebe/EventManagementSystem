using System;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace EventManagementSystem.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly INotificationRepository _notificationRepository;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            IEmailService emailService,
            ISmsService smsService,
            INotificationRepository notificationRepository,
            ILogger<NotificationService> logger)
        {
            _emailService = emailService;
            _smsService = smsService;
            _notificationRepository = notificationRepository;
            _logger = logger;
        }

        public async Task ProcessPendingNotificationsAsync()
        {
            var pendingEmailNotifications = await _notificationRepository.GetPendingEmailNotifications();
            foreach (var emailNotification in pendingEmailNotifications)
            {
                try
                {
                    await _emailService.SendEmailAsync(emailNotification.RecipientEmail, "Subject", emailNotification.Content);
                    emailNotification.Status = NotificationStatus.Processed;
                    await _notificationRepository.UpdateEmailNotification(emailNotification);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending email notification to {Email}", emailNotification.RecipientEmail);
                }
            }

            var pendingSmsNotifications = await _notificationRepository.GetPendingSmsNotifications();
            foreach (var smsNotification in pendingSmsNotifications)
            {
                try
                {
                    await _smsService.SendSmsAsync(smsNotification.PhoneNumber, smsNotification.Message);
                    smsNotification.Status = NotificationStatus.Processed;
                    await _notificationRepository.UpdateSmsNotification(smsNotification);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending SMS notification to {PhoneNumber}", smsNotification.PhoneNumber);
                }
            }
        }
    }
}
