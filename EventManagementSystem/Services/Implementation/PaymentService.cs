using EventManagementSystem.Models;
using Stripe;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentResponseDto> ProcessPaymentAsync(PaymentDto paymentDto)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(paymentDto.Amount * 100), // Stripe deals with the smallest currency unit
                    Currency = paymentDto.Currency,
                    Description = paymentDto.Description,
                    Source = paymentDto.Token,
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                return new PaymentResponseDto
                {
                    PaymentId = charge.Id,
                    Success = charge.Status == "succeeded",
                    Message = charge.Status == "succeeded" ? "Payment successful" : "Payment failed"
                };
            }
            catch (StripeException ex)
            {
                return new PaymentResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
