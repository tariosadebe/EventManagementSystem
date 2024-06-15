using EventManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IEventService
    {
        Task<int> CreateEvent(EventDto eventDto);
        Task<IEnumerable<EventDto>> GetAllEvents();
        Task<EventDto> GetEventById(int eventId);
        Task<bool> UpdateEvent(int eventId, EventDto eventDto);
        Task<bool> DeleteEvent(int eventId);
        Task<IEnumerable<AttendeeDto>> GetRegisteredAttendees(int eventId);
        Task<int> GetTicketsSold(int eventId);
        Task<bool> DeleteEventAsync(int eventId);
        Task GetEventByIdAsync(int eventId);
    }
}
