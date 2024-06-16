using EventManagementSystem.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public class EmailService : IEmailService
    {
        private readonly SendGridOptions _sendGridOptions;

        public EmailService(IOptions<SendGridOptions> sendGridOptions)
        {
            _sendGridOptions = sendGridOptions.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_sendGridOptions.ApiKey);
            var from = new EmailAddress(_sendGridOptions.FromEmail, _sendGridOptions.FromName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }

        Task<bool> IEmailService.SendEmailAsync(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
