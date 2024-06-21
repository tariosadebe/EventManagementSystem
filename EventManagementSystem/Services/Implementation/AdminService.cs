using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public async Task<bool> CreateAdminAsync(AdminDto adminDto)
        {
            var admin = new User
            {
                Username = adminDto.Username,
                Password = adminDto.Password,
                Role = "Admin"
            };

            _context.Users.Add(admin);
            await _context.SaveChangesAsync();
            return true;
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
            return true;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> BanUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {userId} not found.");
                return false;
            }

            user.IsBanned = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<EventDto>> GetAdminEventsAsync(string adminId)
        {
            throw new NotImplementedException();
        }

        public Task<EventDto> GetEventByIdAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEventAsync(int eventId, EventDto eventDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEventAsync(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
