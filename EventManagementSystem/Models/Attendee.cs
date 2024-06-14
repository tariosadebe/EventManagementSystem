using System;
using EventManagementSystem.Models;

namespace EventManagementSystem.Models
{
    public class Attendee
    {
        public int Id { get; set; } // Primary key
        public int EventId { get; set; } // Foreign key to Event
        public string UserId { get; set; } // Foreign key to User
        public DateTime RegistrationTime { get; set; } // Time of registration
        public bool TicketPurchased { get; set; } // Flag indicating if ticket is purchased
        public DateTime? CheckInTime { get; set; } // Time of check-in, nullable

        // Navigation properties
        public Event Event { get; set; } // Navigation property to Event
        public User User { get; set; } // Navigation property to User
    }
}
