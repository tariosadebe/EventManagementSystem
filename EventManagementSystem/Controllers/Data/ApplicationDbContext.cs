using Microsoft.EntityFrameworkCore;
using EventManagementSystem.Models;

namespace EventManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<SmsNotification> SmsNotifications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Ticket> Tickets { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships or other configurations if needed
        }
    }
}
