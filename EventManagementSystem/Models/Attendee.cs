namespace EventManagementSystem.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
        public string CheckInCode { get; set; } // Add this property
        public bool TicketPurchased { get; set; }
        public DateTime? RegistrationTime { get; set; }
        public DateTime? CheckInTime { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
