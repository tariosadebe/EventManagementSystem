using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventService> _logger;

        public EventService(ApplicationDbContext context, ILogger<EventService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var ev = await _context.Events.Include(e => e.Tickets).FirstOrDefaultAsync(e => e.Id == eventId);

            if (ev == null)
            {
                _logger.LogWarning($"Event with ID {eventId} not found.");
                return false;
            }

            if (ev.Tickets.Any(t => t.IsSold))
            {
                _logger.LogWarning($"Event with ID {eventId} cannot be deleted because tickets have been sold.");
                return false;
            }

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Event with ID {eventId} deleted successfully.");
            return true;
        }
    }
}
