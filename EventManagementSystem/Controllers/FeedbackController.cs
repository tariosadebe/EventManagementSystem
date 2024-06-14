using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;
using EventManagementSystem.Services;
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

            await _feedbackService.AddFeedbackAsync(feedbackDto);
            return Ok();
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
