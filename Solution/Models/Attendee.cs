using System.ComponentModel.DataAnnotations;

namespace EventHub.Models
{
    // Technique: DATA ANNOTATIONS
    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        // Home address: plain columns (street, city, country, postal code)
        [Required]
        [MaxLength(150)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        public Badge? Badge { get; set; }             // 0..1 badge (principal side of the 1-1)
    }
}
