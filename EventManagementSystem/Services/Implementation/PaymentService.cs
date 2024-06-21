using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EventManagementSystem.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PaymentService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<PaymentResponseDto> ProcessPaymentAsync(PaymentDto paymentDto)
        {
            var flutterwaveApiKey = _configuration["Flutterwave:ApiKey"];
            var flutterwaveUrl = _configuration["Flutterwave:Url"];

            var paymentRequest = new
            {
                tx_ref = paymentDto.TransactionReference,
                amount = paymentDto.Amount,
                currency = "NGN",  // Using Naira (NGN) as the currency
                redirect_url = paymentDto.RedirectUrl,
                payment_type = "card",
                customer = new
                {
                    email = paymentDto.CustomerEmail,
                    phonenumber = paymentDto.CustomerPhone,
                    name = paymentDto.CustomerName
                }
            };

            var jsonContent = JsonConvert.SerializeObject(paymentRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {flutterwaveApiKey}");

            var response = await _httpClient.PostAsync(flutterwaveUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Payment processing failed: {responseString}");
            }

            var paymentResponse = JsonConvert.DeserializeObject<PaymentResponseDto>(responseString);
            return paymentResponse;
        }
    }
}
