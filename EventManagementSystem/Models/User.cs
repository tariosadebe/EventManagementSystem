namespace EventManagementSystem.Models
{
    public class User
    {
        public string Id { get; set; } // Primary key
        public string UserName { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }

        // Navigation properties
        public ICollection<Attendee> Attendees { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
