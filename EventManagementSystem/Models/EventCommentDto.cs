using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class EventCommentDto
    {
        [Required]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public EventCommentDto()
        {
            CreatedAt = DateTime.UtcNow; // Set default value for CreatedAt
        }
    }
}
