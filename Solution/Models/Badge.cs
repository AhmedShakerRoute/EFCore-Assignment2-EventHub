namespace EventHub.Models
{
    // Technique: SEPARATE CONFIGURATION CLASS (Configurations/BadgeConfiguration.cs)
    public class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; } = string.Empty;   // unique
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }                       // FK (unique => at most one badge per attendee)
        public Attendee Attendee { get; set; } = null!;
    }
}
