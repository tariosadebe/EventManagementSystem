namespace EventManagementSystem.Models
{
    public class EmailNotification
    {
        public int Id { get; set; }
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Content { get; set; } // Add this property
        public NotificationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
