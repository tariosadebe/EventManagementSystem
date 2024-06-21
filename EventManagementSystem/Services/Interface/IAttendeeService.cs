// Services/IAttendeeService.cs
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IAttendeeService
    {
        Task<Attendee> GetAttendeeByIdAsync(int attendeeId);
        Task CreateAttendeeAsync(Attendee newAttendee);
        Task UpdateAttendeeAsync(Attendee updatedAttendee);
        Task<bool> DeleteAttendeeAsync(int attendeeId);
        Task<bool> RegisterAttendeeAsync(int eventId, string userId);
        Task<bool> CheckInAttendeeAsync(int eventId, string userId);
        Task<bool> PurchaseTicketAsync(int eventId, string userId);

    }
}
