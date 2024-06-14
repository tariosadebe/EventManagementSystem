namespace EventManagementSystem.Models
{
    public class SmsNotification
    {
        public int Id { get; set; }
        public string RecipientPhoneNumber { get; set; } // Add this property
        public string Message { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
