namespace EventManagementSystem.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public TicketType TicketType { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
    }
}
