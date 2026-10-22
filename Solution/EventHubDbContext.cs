using EventHub.Configurations;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub
{
    internal class EventHubDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Organizer  -> Data Annotations (on the class)
            // Attendee   -> Data Annotations (on the class)

            // OrganizerProfile -> Fluent API (directly here)
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.ToTable("OrganizerProfiles");

                entity.HasKey(p => p.OrganizerId);

                entity.Property(p => p.Biography).HasMaxLength(1000);
                entity.Property(p => p.WebsiteUrl).HasMaxLength(300);
                entity.Property(p => p.LogoUrl).HasMaxLength(300);

                // 1-1 : the profile cannot exist without its organizer
                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.Profile)
                      .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Event, Badge -> separate configuration classes
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }
    }
}
