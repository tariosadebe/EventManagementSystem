using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public class Event
    {
        public int Id { get; set; } // Primary key
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }

        // Navigation properties
        public ICollection<Attendee> Attendees { get; set; } // Event has many attendees
        public ICollection<EventComment> Comments { get; set; } // Event has many comments
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
