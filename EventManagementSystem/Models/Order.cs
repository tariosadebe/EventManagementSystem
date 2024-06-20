namespace EventManagementSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AttendeeId { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
