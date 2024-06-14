using EventManagementSystem.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EventManagementSystem.Services
{
    public class SmsService : ISmsService
    {
        private readonly TwilioOptions _twilioOptions;
        private readonly ILogger<SmsService> _logger;

        public SmsService(IConfiguration configuration, ILogger<SmsService> logger)
        {
            _twilioOptions = configuration.GetSection("Twilio").Get<TwilioOptions>();
            _logger = logger;

            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);
        }

        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            try
            {
                var messageOptions = new CreateMessageOptions(new PhoneNumber(phoneNumber))
                {
                    From = new PhoneNumber(_twilioOptions.PhoneNumber),
                    Body = message
                };

                var msg = await MessageResource.CreateAsync(messageOptions);
                _logger.LogInformation("Sent SMS to {PhoneNumber}: {MessageSid}", phoneNumber, msg.Sid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending SMS to {PhoneNumber}", phoneNumber);
                throw;
            }
        }
    }
}
