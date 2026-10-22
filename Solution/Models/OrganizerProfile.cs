namespace EventHub.Models
{
    // Technique: FLUENT API (configured inside OnModelCreating)
    public class OrganizerProfile
    {
        public int OrganizerId { get; set; }          // PK and FK at the same time => cannot exist without an Organizer
        public string? Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        public Organizer Organizer { get; set; } = null!;
    }
}
