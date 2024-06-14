namespace EventManagementSystem.Models
{
    public class SmsNotification
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public NotificationStatus Status { get; set; }
    }
}
