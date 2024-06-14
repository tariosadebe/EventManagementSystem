namespace EventManagementSystem.Models
{
    public class PaymentResponseDto
    {
        public string PaymentId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
