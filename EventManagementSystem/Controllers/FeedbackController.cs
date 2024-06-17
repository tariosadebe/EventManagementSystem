using System.Threading.Tasks;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                int feedbackId = await _feedbackService.AddFeedbackAsync(feedbackDto);
                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedbackId }, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding feedback: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetFeedbackByEvent(int eventId)
        {
            var feedback = await _feedbackService.GetFeedbackByEventAsync(eventId);
            return Ok(feedback);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFeedbackByUser(int userId)
        {
            var feedback = await _feedbackService.GetFeedbackByUserAsync(userId);
            return Ok(feedback);
        }
    }
}
