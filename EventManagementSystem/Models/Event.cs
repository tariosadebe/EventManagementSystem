namespace EventManagementSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public string AdminId { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
