using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Location { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Capacity { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
