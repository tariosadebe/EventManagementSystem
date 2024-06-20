using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminService> _logger;

        public AdminService(ApplicationDbContext context, ILogger<AdminService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<bool> CreateAdminAsync(AdminDto adminDto)
        {
            throw new NotImplementedException("The method CreateAdminAsync is not implemented.");
        }

        public async Task<bool> DeleteEventAsync(int eventId, string adminId)
        {
            var eventToDelete = await _context.Events.Include(e => e.Tickets)
                                                     .FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventToDelete == null)
            {
                _logger.LogWarning($"Event with ID {eventId} not found.");
                return false;
            }

            if (eventToDelete.AdminId != adminId)
            {
                _logger.LogWarning($"Admin ID {adminId} does not match the admin ID of the event {eventId}.");
                return false;
            }

            if (eventToDelete.Tickets.Any(t => t.IsSold))
            {
                _logger.LogWarning($"Event {eventId} has sold tickets and cannot be deleted.");
                return false;
            }

            if (eventToDelete.Date > DateTime.Now)
            {
                _logger.LogWarning($"Event {eventId} is upcoming and cannot be deleted.");
                return false;
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Event {eventId} deleted successfully.");
            return true;
        }

        public Task<bool> DeleteEventAsync(int eventId)
        {
            throw new NotImplementedException("The method DeleteEventAsync without adminId is not implemented.");
        }

        public Task<IEnumerable<EventDto>> GetAdminEventsAsync(string adminId)
        {
            throw new NotImplementedException("The method GetAdminEventsAsync is not implemented.");
        }

        public Task<EventDto> GetEventByIdAsync(int eventId)
        {
            throw new NotImplementedException("The method GetEventByIdAsync is not implemented.");
        }

        public Task<bool> UpdateEventAsync(int eventId, EventDto eventDto)
        {
            throw new NotImplementedException("The method UpdateEventAsync is not implemented.");
        }
    }
}
