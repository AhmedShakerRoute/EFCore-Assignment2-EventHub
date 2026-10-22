using System.ComponentModel.DataAnnotations;

namespace EventHub.Models
{
    // Technique: DATA ANNOTATIONS
    public class Organizer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? CompanyName { get; set; }      // "if applicable" => optional

        public bool IsVerified { get; set; }

        public OrganizerProfile? Profile { get; set; }                     // 1-1 (principal side)
        public ICollection<Event> Events { get; set; } = new HashSet<Event>(); // 1-M
    }
}
