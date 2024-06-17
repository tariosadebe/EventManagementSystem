using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IEventService
    {
        Task<bool> DeleteEventAsync(int eventId);
    }
}
