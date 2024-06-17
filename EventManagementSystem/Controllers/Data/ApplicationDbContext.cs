using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public IEnumerable<object> EmailNotifications { get; internal set; }
        public IEnumerable<object> SmsNotifications { get; internal set; }
    }
}
