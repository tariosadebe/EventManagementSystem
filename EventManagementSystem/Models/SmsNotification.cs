namespace EventManagementSystem.Models
{
    public class SmsNotification
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}
