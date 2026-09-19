using System.ComponentModel.DataAnnotations;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.DTOs
{
    public class OrganizerDto
    {
        public int? OrganizerId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone {  get; set; }

    }
}
