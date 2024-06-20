using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public bool IsSent { get; set; }

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public string Subject { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
