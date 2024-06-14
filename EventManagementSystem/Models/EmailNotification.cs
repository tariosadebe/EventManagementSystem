namespace EventManagementSystem.Models
{
    public class EmailNotification
    {
        public int Id { get; set; }
        public string RecipientEmail { get; set; }
        public string Content { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}
