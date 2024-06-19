using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; } // Primary key
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }

        // Additional fields
        public bool IsAdmin { get; set; }
        public bool IsCertifiedAdmin { get; set; }
        public string CertificationDocuments { get; set; }

        // Navigation properties
        public ICollection<Attendee> Attendees { get; set; } // User has many attendees
    }
}
