using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("set-price")]
        public async Task<IActionResult> SetTicketPrice(int ticketId, decimal price)
        {
            var result = await _ticketService.SetTicketPriceAsync(ticketId, price);

            if (result)
                return Ok("Ticket price updated successfully.");
            else
                return NotFound("Ticket not found or price update failed.");
        }
    }
}
