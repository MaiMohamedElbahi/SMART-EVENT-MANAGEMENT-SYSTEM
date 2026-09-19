using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
        [Range(1, 10000)]
        public int Capacity { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } 

        public int VenueId { get; set; }
        public Venue Venue { get; set; } 

        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
