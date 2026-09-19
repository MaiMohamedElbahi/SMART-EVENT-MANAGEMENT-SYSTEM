using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [MaxLength(30)]
        public string Status { get; set; }


        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; } 

        [Required]
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } 

    }
}
