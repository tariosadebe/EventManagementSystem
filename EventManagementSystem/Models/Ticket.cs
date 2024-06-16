// Models/Ticket.cs
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Required]
        public string TicketType { get; set; } // Regular or VIP

        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public string UserId { get; set; } 
        public User User { get; set; }
    }
}
