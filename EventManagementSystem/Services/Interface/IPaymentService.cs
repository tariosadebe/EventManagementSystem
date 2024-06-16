using EventManagementSystem.Models;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPaymentAsync(PaymentDto paymentDto);
    }
}
