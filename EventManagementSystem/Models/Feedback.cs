using System;

namespace EventManagementSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }  // Renamed from 'Comment' for consistency
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Renamed from 'DateCreated' for consistency

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
