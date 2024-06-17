using EventManagementSystem.Models;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(PaymentDto paymentDto);
    }
}
