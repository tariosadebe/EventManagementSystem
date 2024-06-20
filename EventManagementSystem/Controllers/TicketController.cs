using EventManagementSystem.Models;
using EventManagementSystem.Services;
using EventManagementSystem.Services.Interfaces;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDto ticketDto)
        {
            var result = await _ticketService.CreateTicketAsync(ticketDto);

            if (result)
                return Ok("Ticket created successfully.");
            else
                return BadRequest("Ticket creation failed.");
        }

        // Other ticket controller methods...
    }
}
