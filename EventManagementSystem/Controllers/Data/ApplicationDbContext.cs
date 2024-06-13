using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventComment> EventComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); // Ensure unique email addresses
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Comments) // Event has many comments
                .WithOne(ec => ec.Event) // Each comment belongs to one event
                .HasForeignKey(ec => ec.EventId); // Foreign key
        }
    }
}
