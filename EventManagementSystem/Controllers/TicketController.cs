using EventManagementSystem.Models;
using EventManagementSystem.Services;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = new Ticket
            {
                EventId = ticketDto.EventId,
                TicketType = ticketDto.TicketType,
                Price = ticketDto.Price,
                IsVIP = ticketDto.IsVIP, // Handling the new property
                IsSold = false,
                UserId = ticketDto.UserId // Ensuring UserId is included
            };

            try
            {
                await _ticketService.CreateTicketAsync(ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
