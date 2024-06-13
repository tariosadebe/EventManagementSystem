// Services/IAttendeeService.cs
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IAttendeeService
    {
        Task<bool> RegisterAttendee(int eventId, string userId);

        Task<bool> PurchaseTicket(int eventId, string userId);

        Task<bool> CheckInAttendee(int eventId, string userId);
    }
}
