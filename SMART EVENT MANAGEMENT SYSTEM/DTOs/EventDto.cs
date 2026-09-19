using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.DTOs
{
    public class EventDto
    {
        public int? EventId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Category { get; set; }
        public int? Capacity { get; set; }
        public int? OrganizerId { get; set; }
        public int? VenueId { get; set; }
    }
}
