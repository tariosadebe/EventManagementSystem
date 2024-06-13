using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }

        public ICollection<Attendee> Attendees { get; set; }

        public ICollection<EventComment> Comments { get; set; }
    }
}
