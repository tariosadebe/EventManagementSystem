using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context; private readonly ILogger<EventService> _logger;

        public EventService(ApplicationDbContext context, ILogger<EventService> logger)
        {
            _context = context; _logger = logger;
        }

        public async Task<Event> CreateEvent(EventDto eventDto)
        {
            try
            {
                var newEvent = new Event
                {
                    Title = eventDto.Title,
                    Description = eventDto.Description,
                    Date = eventDto.Date,
                    Location = eventDto.Location,
                    Organizer = eventDto.Organizer
                };

                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();

                return newEvent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating event");
                throw;
            }
        }

        public async Task<Event> GetEventById(int eventId)
        {
            try
            {
                return await _context.Events.FindAsync(eventId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving event with ID {EventId}", eventId);
                throw;
            }
        }

        public async Task<List<Event>> GetAllEvents()
        {
            try
            {
                return await _context.Events.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all events");
                throw;
            }
        }

        public async Task<Event> UpdateEvent(int eventId, EventDto eventDto)
        {
            try
            {
                var existingEvent = await _context.Events.FindAsync(eventId);

                if (existingEvent == null) return null;

                existingEvent.Title = eventDto.Title;
                existingEvent.Description = eventDto.Description;
                existingEvent.Date = eventDto.Date;
                existingEvent.Location = eventDto.Location;
                existingEvent.Organizer = eventDto.Organizer;

                _context.Events.Update(existingEvent);
                await _context.SaveChangesAsync();

                return existingEvent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating event with ID {EventId}", eventId);
                throw;
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var existingEvent = await _context.Events.FindAsync(eventId);

                if (existingEvent == null) return false;

                _context.Events.Remove(existingEvent);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting event with ID {EventId}", eventId);
                throw;
            }
        }
    }
}
