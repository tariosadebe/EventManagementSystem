using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public bool IsSold { get; set; }

        [Required]
        public string TicketType { get; set; } // "Regular" or "VIP"
    }
}
