namespace EventHub.Models
{
    // Technique: SEPARATE CONFIGURATION CLASS (Configurations/EventConfiguration.cs)
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }        // optional
        public int MaxAttendees { get; set; }

        public int OrganizerId { get; set; }          // FK
        public Organizer Organizer { get; set; } = null!;
    }
}
