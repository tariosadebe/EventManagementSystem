namespace EventManagementSystem.Models
{
    public class CreateTicketRequest
    {
        public TicketType TicketType { get; set; }
        public decimal Price { get; set; }
    }
}
