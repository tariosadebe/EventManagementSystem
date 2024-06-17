using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<int> AddFeedbackAsync(FeedbackDto feedbackDto);
        Task<Feedback> GetFeedbackByIdAsync(int id);
        Task<IEnumerable<Feedback>> GetFeedbackByEventAsync(int eventId);
        Task<IEnumerable<Feedback>> GetFeedbackByUserAsync(int userId);
        Task<IEnumerable<Feedback>> GetFeedbackForEventAsync(int eventId);
    }
}
