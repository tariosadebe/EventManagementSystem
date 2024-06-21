using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EventManagementSystem.Services.Implementation
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public SmsService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            try
            {
                var twilioAccountSid = _configuration["Twilio:AccountSid"];
                var twilioAuthToken = _configuration["Twilio:AuthToken"];
                var twilioPhoneNumber = _configuration["Twilio:PhoneNumber"];

                var url = $"https://api.twilio.com/2010-04-01/Accounts/{twilioAccountSid}/Messages.json";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("To", phoneNumber),
                    new KeyValuePair<string, string>("From", twilioPhoneNumber),
                    new KeyValuePair<string, string>("Body", message)
                });

                var authenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{twilioAccountSid}:{twilioAuthToken}"));
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authenticationString);

                using (var response = await _httpClient.PostAsync(url, content))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException($"Failed to send SMS: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while sending SMS: {ex.Message}");
            }
        }
    }
}
