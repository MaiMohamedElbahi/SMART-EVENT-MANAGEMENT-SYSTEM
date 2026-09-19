using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }

        public List<Registration> Registrations { get; set; } = new List<Registration>();

    }
}
