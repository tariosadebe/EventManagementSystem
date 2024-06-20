using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventManagementSystem.Services.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AttendeeService> _logger;

        public AttendeeService(ApplicationDbContext context, ILogger<AttendeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Attendee> GetAttendeeByIdAsync(int attendeeId)
        {
            return await _context.Attendees.FirstOrDefaultAsync(a => a.Id == attendeeId);
        }

        public async Task CreateAttendeeAsync(Attendee newAttendee)
        {
            _context.Attendees.Add(newAttendee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendeeAsync(Attendee updatedAttendee)
        {
            _context.Attendees.Update(updatedAttendee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAttendeeAsync(int attendeeId)
        {
            var attendee = await GetAttendeeByIdAsync(attendeeId);
            if (attendee != null)
            {
                _context.Attendees.Remove(attendee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterAttendeeAsync(int eventId, string userId)
        {
            var attendee = new Attendee
            {
                EventId = eventId,
                UserId = userId,
                RegistrationDate = DateTime.UtcNow
            };

            _context.Attendees.Add(attendee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PurchaseTicketAsync(int eventId, string userId)
        {
            var ticket = new Ticket
            {
                EventId = eventId,
                UserId = userId,
                PurchaseDate = DateTime.UtcNow
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckInAttendeeAsync(int eventId, string userId)
        {
            var attendee = await _context.Attendees
                .FirstOrDefaultAsync(a => a.EventId == eventId && a.UserId == userId);

            if (attendee != null)
            {
                attendee.CheckedIn = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
