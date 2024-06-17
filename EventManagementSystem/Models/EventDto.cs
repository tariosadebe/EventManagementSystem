using System;

namespace EventManagementSystem.Models
{
    public class EventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int Id { get; internal set; }
        public object Title { get; internal set; }
        public object AdminId { get; internal set; }
    }
}
