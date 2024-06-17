using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddFeedbackAsync(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback
            {
                EventId = feedbackDto.EventId,
                UserId = feedbackDto.UserId,
                Rating = feedbackDto.Rating,
                Comments = feedbackDto.Comments,  // Corrected to match the model property name
                CreatedAt = DateTime.UtcNow  // Ensure this matches the model property name
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return feedback.Id;
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedbacks
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackForEventAsync(int eventId)
        {
            return await _context.Feedbacks
                .Where(f => f.EventId == eventId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByUserAsync(int userId)
        {
            return await _context.Feedbacks
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public Task<IEnumerable<Feedback>> GetFeedbackByEventAsync(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
