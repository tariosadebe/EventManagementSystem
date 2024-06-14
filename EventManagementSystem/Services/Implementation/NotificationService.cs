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

        public NotificationService(IEmailService emailService, ISmsService smsService,
            INotificationRepository notificationRepository, ILogger<NotificationService> logger)
        {
            _emailService = emailService;
            _smsService = smsService;
            _notificationRepository = notificationRepository;
            _logger = logger;
        }

        public async Task ProcessPendingNotificationsAsync()
        {
            await ProcessEmailNotifications();
            await ProcessSmsNotifications();
        }

        public async Task ProcessEmailNotifications()
        {
            var pendingEmails = await _notificationRepository.GetPendingEmailNotifications();

            foreach (var email in pendingEmails)
            {
                try
                {
                    await _emailService.SendEmailAsync(email.RecipientEmail, email.Subject, email.Body);
                    email.Status = NotificationStatus.Processed;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending email to {RecipientEmail}", email.RecipientEmail);
                    email.Status = NotificationStatus.Failed;
                }
                await _notificationRepository.UpdateEmailNotification(email);
            }
        }

        public async Task ProcessSmsNotifications()
        {
            var pendingSms = await _notificationRepository.GetPendingSmsNotifications();

            foreach (var sms in pendingSms)
            {
                try
                {
                    await _smsService.SendSmsAsync(sms.RecipientPhoneNumber, sms.Message);
                    sms.Status = NotificationStatus.Processed;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending SMS to {RecipientPhoneNumber}", sms.RecipientPhoneNumber);
                    sms.Status = NotificationStatus.Failed;
                }
                await _notificationRepository.UpdateSmsNotification(sms);
            }
        }
    }
}
