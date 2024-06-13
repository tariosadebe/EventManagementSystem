using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event> CreateEvent(EventDto eventDto)
        {
            var newEvent = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Date = eventDto.Date,
                Location = eventDto.Location
                // Assign other properties as needed
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent;
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> UpdateEvent(int eventId, EventDto eventDto)
        {
            var existingEvent = await _context.Events.FindAsync(eventId);

            if (existingEvent == null)
                return null;

            existingEvent.Title = eventDto.Title;
            existingEvent.Description = eventDto.Description;
            existingEvent.Date = eventDto.Date;
            existingEvent.Location = eventDto.Location;
            // Update other properties

            _context.Events.Update(existingEvent);
            await _context.SaveChangesAsync();

            return existingEvent;
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var existingEvent = await _context.Events.FindAsync(eventId);

            if (existingEvent == null)
                return false;

            _context.Events.Remove(existingEvent);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
