using EventManagementSystem.Models;
using EventManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementSystem.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateEvent(EventDto eventDto)
        {
            var newEvent = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Date = eventDto.Date,
                Location = eventDto.Location,
                AdminId = eventDto.AdminId // Ensure AdminId is an integer
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.Id;
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents()
        {
            var events = await _context.Events
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date,
                    Location = e.Location,
                    AdminId = e.AdminId
                })
                .ToListAsync();

            return events;
        }

        public async Task<EventDto> GetEventById(int eventId)
        {
            var @event = await _context.Events
                .Where(e => e.Id == eventId)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date,
                    Location = e.Location,
                    AdminId = e.AdminId
                })
                .FirstOrDefaultAsync();

            return @event;
        }

        public async Task<bool> UpdateEvent(int eventId, EventDto eventDto)
        {
            var existingEvent = await _context.Events.FindAsync(eventId);

            if (existingEvent == null)
                return false;

            existingEvent.Title = eventDto.Title;
            existingEvent.Description = eventDto.Description;
            existingEvent.Date = eventDto.Date;
            existingEvent.Location = eventDto.Location;

            _context.Events.Update(existingEvent);
            await _context.SaveChangesAsync();

            return true;
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

        public async Task<IEnumerable<AttendeeDto>> GetRegisteredAttendees(int eventId)
        {
            var attendees = await _context.Attendees
                .Where(a => a.EventId == eventId)
                .Select(a => new AttendeeDto
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    EventId = a.EventId,
                    RegistrationStatus = a.RegistrationStatus.ToString() // Convert enum to string if necessary
                    // Include other attendee properties as needed
                })
                .ToListAsync();

            return attendees;
        }

        public async Task<int> GetTicketsSold(int eventId)
        {
            var ticketsSold = await _context.Attendees
                .Where(a => a.EventId == eventId && a.RegistrationStatus == RegistrationStatus.Paid)
                .CountAsync();

            return ticketsSold;
        }

        public Task<bool> DeleteEventAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task GetEventByIdAsync(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
