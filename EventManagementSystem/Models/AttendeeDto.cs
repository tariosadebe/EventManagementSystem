using System;

namespace EventManagementSystem.Models
{
    public class AttendeeDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
        public string RegistrationStatus { get; set; }
        // Other properties as needed
    }
}
