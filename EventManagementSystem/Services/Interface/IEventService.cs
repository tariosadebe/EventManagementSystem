using EventManagementSystem.Models;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IEventService
    {
        Task<bool> DeleteEventAsync(int id);
        Task UpdateEventAsync(Event updatedEvent);
        Task CreateEventAsync(Event newEvent);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);

    }
}
