namespace EventManagementSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public TicketType TicketType { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public bool IsVIP { get; set; } 
        public bool IsSold { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
        public bool IsPaid { get; internal set; }
        public string Code { get; internal set; }
        public TicketType Type { get; internal set; }
    }
}
