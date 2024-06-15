using EventManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IAdminService
    {
        Task<bool> CreateAdminAsync(AdminDto adminDto);
        Task<IEnumerable<EventDto>> GetAdminEventsAsync(string adminId);
        Task<EventDto> GetEventByIdAsync(int eventId);
        Task<bool> UpdateEventAsync(int eventId, EventDto eventDto);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
