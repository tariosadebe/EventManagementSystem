using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManagementSystem.Models;
using EventManagementSystem.Services;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventDto eventDto)
        {
            var eventId = await _eventService.CreateEvent(eventDto);
            if (eventId > 0)
            {
                return Ok(eventId);
            }
            return BadRequest("Failed to create event.");
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var @event = await _eventService.GetEventById(eventId);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] EventDto eventDto)
        {
            var result = await _eventService.UpdateEvent(eventId, eventDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Event updated successfully.");
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var result = await _eventService.DeleteEvent(eventId);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Event deleted successfully.");
        }

        [HttpGet("{eventId}/attendees")]
        public async Task<IActionResult> GetRegisteredAttendees(int eventId)
        {
            var attendees = await _eventService.GetRegisteredAttendees(eventId);
            return Ok(attendees);
        }

        [HttpGet("{eventId}/tickets-sold")]
        public async Task<IActionResult> GetTicketsSold(int eventId)
        {
            var ticketsSold = await _eventService.GetTicketsSold(eventId);
            return Ok(ticketsSold);
        }

        // Add more endpoints as needed for event management
    }
}
