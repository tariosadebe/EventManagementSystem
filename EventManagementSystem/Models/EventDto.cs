public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AdminId { get; set; }  // Ensure it's an int
}
