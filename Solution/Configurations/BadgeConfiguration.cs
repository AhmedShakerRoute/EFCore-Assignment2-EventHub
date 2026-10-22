using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations
{
    internal class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BadgeNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            // "uniquely numbered per attendee"
            builder.HasIndex(b => b.BadgeNumber)
                   .IsUnique();

            builder.Property(b => b.IssuedDate)
                   .HasColumnType("date");

            // 1-1 : an Attendee has at most one Badge, a Badge belongs to exactly one Attendee
            builder.HasOne(b => b.Attendee)
                   .WithOne(a => a.Badge)
                   .HasForeignKey<Badge>(b => b.AttendeeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
