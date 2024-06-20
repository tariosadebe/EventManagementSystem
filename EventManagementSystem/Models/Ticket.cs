namespace EventManagementSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public TicketType TicketType { get; set; }
        public string UserId { get; set; }
        public bool IsPaid { get; internal set; }
        public string Code { get; internal set; }
        public bool IsSold { get; internal set; }
    }
}
