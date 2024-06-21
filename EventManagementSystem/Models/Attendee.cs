using EventManagementSystem.Models;

public class Attendee
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int EventId { get; set; }
    public string CheckInCode { get; set; }
    public bool TicketPurchased { get; set; }
    public DateTime? RegistrationTime { get; set; }
    public DateTime? CheckInTime { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }  
    public User User { get; set; }
    public Event Event { get; set; }
    public DateTime RegistrationDate { get; internal set; }
    public bool CheckedIn { get; internal set; }
}
