using System;
using System.Threading;
using System.Threading.Tasks;
using EventManagementSystem.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventManagementSystem.BackgroundServices
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<NotificationBackgroundService> _logger;

        public NotificationBackgroundService(INotificationService notificationService, ILogger<NotificationBackgroundService> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Notification background service running.");

                try
                {
                    await _notificationService.ProcessPendingNotificationsAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while processing notifications.");
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
