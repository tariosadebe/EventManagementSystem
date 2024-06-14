﻿using System;
using System.Collections.Generic;
using System.Threading;
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
                                   INotificationRepository notificationRepository,
                                   ILogger<NotificationService> logger)
        {
            _emailService = emailService;
            _smsService = smsService;
            _notificationRepository = notificationRepository;
            _logger = logger;
        }

        public async Task ProcessPendingNotifications(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing pending notifications...");

            var pendingEmails = await _notificationRepository.GetPendingEmailNotifications();
            var pendingSms = await _notificationRepository.GetPendingSmsNotifications();

            foreach (var email in pendingEmails)
            {
                if (cancellationToken.IsCancellationRequested) break;

                try
                {
                    await _emailService.SendEmailAsync(email.To, email.Subject, email.Body);
                    email.Status = NotificationStatus.Processed;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending email to {To}", email.To);
                    email.Status = NotificationStatus.Failed;
                }

                await _notificationRepository.UpdateEmailNotification(email);
            }

            foreach (var sms in pendingSms)
            {
                if (cancellationToken.IsCancellationRequested) break;

                try
                {
                    await _smsService.SendSmsAsync(sms.To, sms.Message);
                    sms.Status = NotificationStatus.Processed;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending SMS to {To}", sms.To);
                    sms.Status = NotificationStatus.Failed;
                }

                await _notificationRepository.UpdateSmsNotification(sms);
            }
        }

        public Task ProcessPendingNotifications()
        {
            throw new NotImplementedException();
        }
    }
}
