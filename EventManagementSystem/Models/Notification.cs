namespace EventManagementSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public object Email { get; internal set; }
        public object Subject { get; internal set; }
        public bool IsSent { get; internal set; }
    }
}
