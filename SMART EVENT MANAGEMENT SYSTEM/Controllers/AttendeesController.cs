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
    public class AttendeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AttendeesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAttendees()
        {
            var modelentity = _context.Attendees.ToList();
            if(modelentity.Count == 0 || modelentity == null)
            {
                return BadRequest("There are no Attendees");
            } 
            return Ok(_mapper.Map<List<AttendeeDto>>(modelentity));
        }
        [HttpGet("{id}")]
        public IActionResult GetAttendeeById(int id)
        {
            if (_context.Attendees.Find(id) == null)
            {
                return BadRequest("Attendee Not Found");
            }
            return Ok(_mapper.Map<AttendeeDto>(_context.Attendees.Find(id)));
        }
        [HttpPut("{id}")]
        public IActionResult PutAttendeeById(int id, AttendeeDto dtoentity)
        {
            var modelentity = _context.Attendees.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Attendee Not Found");
            }
            _mapper.Map(dtoentity, modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateAttendee(AttendeeDto dtoentity)
        {
            var modelentity = _mapper.Map<Attendee>(dtoentity);
            _context.Attendees.Add(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAttendeeById(int id, AttendeeDto dtoentity)
        {
            var modelentity = _context.Attendees.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Attendee Not Found");
            }
            if (dtoentity.FullName != null)
            {
                modelentity.FullName = dtoentity.FullName;
            }
            if (dtoentity.Email != null)
            {
                modelentity.Email = dtoentity.Email;
            }
            if (dtoentity.Phone != null)
            {
                modelentity.Phone = dtoentity.Phone;
            }
            _context.Update(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAttendeeById(int id)
        {
            if (_context.Attendees.Find(id) == null)
            {
                return BadRequest("Attendee Not Found");
            }
            _context.Attendees.Remove(_context.Attendees.Find(id));
            return Ok();
        }
    }
}
