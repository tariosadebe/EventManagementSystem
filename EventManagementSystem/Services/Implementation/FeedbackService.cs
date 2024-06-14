using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFeedbackAsync(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback
            {
                EventId = feedbackDto.EventId,
                UserId = feedbackDto.UserId,
                Rating = feedbackDto.Rating,
                Comments = feedbackDto.Comments
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Feedback>> GetFeedbackByEventAsync(int eventId)
        {
            return await _context.Feedbacks
                .Where(f => f.EventId == eventId)
                .ToListAsync();
        }

        public async Task<List<Feedback>> GetFeedbackByUserAsync(int userId)
        {
            return await _context.Feedbacks
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
    }
}
