using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EventManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CheckInController> _logger;

        public CheckInController(ApplicationDbContext context, ILogger<CheckInController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateCheckIn([FromBody] CheckInDto checkInDto)
        {
            var attendee = await _context.Attendees
                .FirstOrDefaultAsync(a => a.CheckInCode == checkInDto.CheckInCode);

            if (attendee == null)
            {
                _logger.LogWarning($"Invalid check-in code: {checkInDto.CheckInCode}");
                return NotFound("Invalid check-in code.");
            }

            if (attendee.CheckInTime != null)
            {
                _logger.LogWarning($"Attendee with check-in code: {checkInDto.CheckInCode} has already checked in.");
                return BadRequest("Attendee already checked in.");
            }

            attendee.CheckInTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Check-in successful for code {CheckInCode}", checkInDto.CheckInCode);

            return Ok("Check-in successful.");
        }
    }

    public class CheckInDto
    {
        public string CheckInCode { get; set; }
    }
}
