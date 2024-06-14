using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface IFeedbackService
    {
        Task AddFeedbackAsync(FeedbackDto feedbackDto);
        Task<List<Feedback>> GetFeedbackByEventAsync(int eventId);
        Task<List<Feedback>> GetFeedbackByUserAsync(int userId);
    }
}
