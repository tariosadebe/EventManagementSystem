// EventComment.cs (in EventManagementSystem.Models namespace)

using System;

namespace EventManagementSystem.Models
{
    public class EventComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key to relate to Event
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
