namespace EventManagementSystem.Models
{
    public class PaymentDto
    {
        public string Token { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd";
        public string Description { get; set; }
    }
}