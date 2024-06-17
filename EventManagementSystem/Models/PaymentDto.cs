namespace EventManagementSystem.Models
{
    public class PaymentDto
    {
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int EventId { get; internal set; }
        public string UserId { get; internal set; }
    }
}
