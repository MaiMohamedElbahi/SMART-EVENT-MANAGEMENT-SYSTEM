using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMART_EVENT_MANAGEMENT_SYSTEM.Data;
using SMART_EVENT_MANAGEMENT_SYSTEM.DTOs;
using SMART_EVENT_MANAGEMENT_SYSTEM.Models;

namespace SMART_EVENT_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _context.Events.ToList();
            if(events.Count == 0 || events == null)
            {
                return BadRequest("There are no events");
            } 
            return Ok(_mapper.Map<List<EventDto>>(events));
        }
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            if (_context.Events.Find(id) == null)
            {
                return BadRequest("Event Not Found");
            }
            return Ok(_mapper.Map<EventDto>(_context.Events.Find(id)));
        }
        [HttpPut("{id}")]
        public IActionResult PutEventById(int id, EventDto eve)
        {
            var cevent = _context.Events.Find(id);
            if (cevent == null)
            {
                return BadRequest("Event Not Found");
            }
            _mapper.Map(eve, cevent);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDto eve)
        {
            var even = _mapper.Map<Event>(eve);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEventById(int id, EventDto eve)
        {
            var cevent = _context.Events.Find(id);
            if (cevent == null)
            {
                return BadRequest("Event Not Found");
            }
            if (eve.Description != null)
            {
                cevent.Description = eve.Description;
            }
            if (eve.Title != null)
            {
                cevent.Title = eve.Title;
            }
            if (eve.Category != null)
            {
                cevent.Category = eve.Category;
            }
            if (eve.Capacity.HasValue)
            {
                cevent.Capacity = eve.Capacity.Value;
            }
            if (eve.EventDate.HasValue)
            {
                cevent.EventDate = eve.EventDate.Value;
            }
            if (eve.StartTime.HasValue)
            {
                cevent.StartTime = eve.StartTime.Value;
            }
            if (eve.EndTime.HasValue)
            {
                cevent.EndTime = eve.EndTime.Value;
            }
            if (eve.OrganizerId.HasValue)
            {
                cevent.OrganizerId = eve.OrganizerId.Value;
            }
            if (eve.VenueId.HasValue)
            {
                cevent.VenueId = eve.VenueId.Value;
            }
            _context.Update(cevent);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEventById(int id)
        {
            if (_context.Events.Find(id) == null)
            {
                return BadRequest("Event Not Found");
            }
            _context.Events.Remove(_context.Events.Find(id));
            return Ok();
        }
    }
}
