namespace EventManagementSystem.Models
{
    public class PaymentDto
    {
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
