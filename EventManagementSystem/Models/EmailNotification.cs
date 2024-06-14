namespace EventManagementSystem.Models
{
    public class EmailNotification
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public NotificationStatus Status { get; set; }
    }
}
