using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdminService> _logger;
        private readonly ApplicationDbContext _context;

        public AdminService(UserManager<ApplicationUser> userManager, ILogger<AdminService> logger, ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        public async Task<bool> CreateAdminAsync(AdminDto adminDto)
        {
            var user = new ApplicationUser
            {
                UserName = adminDto.Username,
                Email = adminDto.Email,
                Name = $"{adminDto.FirstName} {adminDto.LastName}", // Assuming Name represents full name
                Phone = adminDto.Phone,
                Address = adminDto.Address,
                City = adminDto.City,
                State = adminDto.State,
                ZipCode = adminDto.ZipCode,
                Country = adminDto.Country
            };

            var result = await _userManager.CreateAsync(user, adminDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Admin);
                return true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError($"Error creating admin user: {error.Description}");
                }
                return false;
            }
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var eventToDelete = await _context.Events.FindAsync(eventId);
            if (eventToDelete == null)
            {
                _logger.LogError($"Event with ID {eventId} not found.");
                return false;
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EventDto>> GetAdminEventsAsync(string adminId)
        {
            if (!int.TryParse(adminId, out int adminIdInt))
            {
                _logger.LogError($"Invalid admin ID: {adminId}");
                return Enumerable.Empty<EventDto>();
            }

            var events = await _context.Events
                .Where(e => e.AdminId == adminIdInt)
                .ToListAsync();

            return events.Select(e => new EventDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Location = e.Location,
                AdminId = e.AdminId
            });
        }

        public async Task<EventDto> GetEventByIdAsync(int eventId)
        {
            var @event = await _context.Events.FindAsync(eventId);
            if (@event == null)
            {
                _logger.LogError($"Event with ID {eventId} not found.");
                return null;
            }

            return new EventDto
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                Date = @event.Date,
                Location = @event.Location,
                AdminId = @event.AdminId
            };
        }

        public async Task<bool> UpdateEventAsync(int eventId, EventDto eventDto)
        {
            var eventToUpdate = await _context.Events.FindAsync(eventId);
            if (eventToUpdate == null)
            {
                _logger.LogError($"Event with ID {eventId} not found.");
                return false;
            }

            eventToUpdate.Title = eventDto.Title;
            eventToUpdate.Description = eventDto.Description;
            eventToUpdate.Date = eventDto.Date;
            eventToUpdate.Location = eventDto.Location;

            _context.Events.Update(eventToUpdate);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
