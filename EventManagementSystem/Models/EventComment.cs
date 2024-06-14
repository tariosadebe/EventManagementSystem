using System;

namespace EventManagementSystem.Models
{
    public class EventComment
    {
        public int Id { get; set; } // Primary key
        public int EventId { get; set; } // Foreign key to Event
        public string UserId { get; set; } // Foreign key to User
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Event Event { get; set; } // Navigation property to Event
        public User User { get; set; } // Navigation property to User
    }
}
