namespace EventManagementSystem.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AttendeeId { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
