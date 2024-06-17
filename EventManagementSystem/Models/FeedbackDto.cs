namespace EventManagementSystem.Models
{
    public class FeedbackDto
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }  // Ensure this matches the model property name
    }
}
