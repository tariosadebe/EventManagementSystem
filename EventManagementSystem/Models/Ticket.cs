
namespace EventManagementSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AttendeeId { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }

        // Foreign key to Order
        public int? OrderId { get; set; }  // Nullable in case the ticket is not part of an order yet

        // Navigation properties
        public Order Order { get; set; }
        public Event Event { get; set; }
        public User Attendee { get; set; }
        public TicketType TicketType { get; internal set; }
        public string UserId { get; internal set; }
        public bool IsPaid { get; internal set; }
        public string Code { get; internal set; }
        public DateTime PurchaseDate { get; internal set; }
    }
}
