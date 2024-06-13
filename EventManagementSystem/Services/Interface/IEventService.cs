using EventManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IEventService
    {
        Task<Event> CreateEvent(EventDto eventDto);
        Task<Event> GetEventById(int eventId);
        Task<List<Event>> GetAllEvents();
        Task<Event> UpdateEvent(int eventId, EventDto eventDto);
        Task<bool> DeleteEvent(int eventId);
    }
}
