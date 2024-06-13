using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService; private readonly ILogger<EventsController> _logger;

        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            _eventService = eventService; _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            try
            {
                var events = await _eventService.GetAllEvents();
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all events");
                return StatusCode(500, new { Message = "An error occurred while retrieving events." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            try
            {
                var eventItem = await _eventService.GetEventById(id);

                if (eventItem == null) return NotFound(new { Message = "Event not found." });

                return Ok(eventItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving event with ID {EventId}", id);
                return StatusCode(500, new { Message = "An error occurred while retrieving the event." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(EventDto eventDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var newEvent = await _eventService.CreateEvent(eventDto);
                return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating event");
                return StatusCode(500, new { Message = "An error occurred while creating the event." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventDto eventDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var updatedEvent = await _eventService.UpdateEvent(id, eventDto);
                if (updatedEvent == null) return NotFound(new { Message = "Event not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating event with ID {EventId}", id);
                return StatusCode(500, new { Message = "An error occurred while updating the event." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var result = await _eventService.DeleteEvent(id);

                if (!result) return NotFound(new { Message = "Event not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting event with ID {EventId}", id);
                return StatusCode(500, new { Message = "An error occurred while deleting the event." });
            }
        }
    }
}
