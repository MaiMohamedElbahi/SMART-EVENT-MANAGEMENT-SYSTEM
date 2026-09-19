using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.DTOs
{
    public class VenueDto
    {
        public int? VenueId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int? Capacity { get; set; }
    }
}
