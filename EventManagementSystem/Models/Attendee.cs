using System;
using EventManagementSystem.Models;

namespace EventManagementSystem.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public DateTime RegistrationTime { get; set; }
        public bool TicketPurchased { get; set; }
        public DateTime? CheckInTime { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
