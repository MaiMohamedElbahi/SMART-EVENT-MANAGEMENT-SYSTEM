using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.DTOs
{
    public class RegistrationDto
    {
        public int? RegistrationId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Status { get; set; }
        public int? EventId { get; set; }
        public int? AttendeeId { get; set; }

    }
}
