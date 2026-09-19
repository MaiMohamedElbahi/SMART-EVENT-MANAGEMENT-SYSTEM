using AutoMapper;
using SMART_EVENT_MANAGEMENT_SYSTEM.DTOs;
using SMART_EVENT_MANAGEMENT_SYSTEM.Models;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>().ForMember(e => e.EventId, c => c.Ignore());
            CreateMap<Attendee, AttendeeDto>().ReverseMap().ForMember(e => e.AttendeeId, c => c.Ignore());
            CreateMap<Organizer, OrganizerDto>().ReverseMap().ForMember(e => e.OrganizerId, c => c.Ignore());
            CreateMap<Registration, RegistrationDto>().ReverseMap().ForMember(e => e.RegistrationDate, c => c.Ignore());
            CreateMap<Venue, VenueDto>().ReverseMap().ForMember(e => e.VenueId, c => c.Ignore());
        }
    }
}
