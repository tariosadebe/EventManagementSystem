namespace EventManagementSystem.Models
{
    public class CreateOrderRequest
    {
        public int EventId { get; set; }
        public string AttendeeId { get; set; }
        public List<CreateTicketRequest> Tickets { get; set; }
    }
}
