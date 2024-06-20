using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

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
            return await _context.Attendees
                .FirstOrDefaultAsync(a => a.Id == attendeeId);
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

        public Task<bool> RegisterAttendee(int eventId, string userId)
        {
            throw new NotImplementedException("The method RegisterAttendee is not implemented.");
        }

        public Task<bool> PurchaseTicket(int eventId, string userId)
        {
            throw new NotImplementedException("The method PurchaseTicket is not implemented.");
        }

        public Task<bool> CheckInAttendee(int eventId, string userId)
        {
            throw new NotImplementedException("The method CheckInAttendee is not implemented.");
        }
    }
}
