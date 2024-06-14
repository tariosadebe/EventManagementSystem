using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(PaymentDto paymentDto)
        {
            var result = await _paymentService.ProcessPaymentAsync(paymentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
