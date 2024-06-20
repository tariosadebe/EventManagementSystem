using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Tickets)
                .WithOne(t => t.Order)
                .HasForeignKey(t => t.OrderId);

            modelBuilder.Entity<Notification>()
                .Ignore(n => n.Email)
                .Ignore(n => n.Subject);
        }
    }
}
