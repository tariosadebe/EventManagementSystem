namespace EventManagementSystem.Models
{
    public class PaymentDto
    {
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int EventId { get; internal set; }
        public string UserId { get; internal set; }
        public object TransactionReference { get; internal set; }
        public object RedirectUrl { get; internal set; }
        public object CustomerEmail { get; internal set; }
        public object CustomerPhone { get; internal set; }
        public object CustomerName { get; internal set; }
    }
}
