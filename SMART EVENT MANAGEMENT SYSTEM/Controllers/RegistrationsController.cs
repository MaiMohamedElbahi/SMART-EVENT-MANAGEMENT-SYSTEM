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
    public class RegistrationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RegistrationsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            var modelentity = _context.Registrations.ToList();
            if(modelentity.Count == 0 || modelentity == null)
            {
                return BadRequest("There are no Registrations");
            } 
            return Ok(_mapper.Map<List<RegistrationDto>>(modelentity));
        }
        [HttpGet("{id}")]
        public IActionResult GetRegistrationById(int id)
        {
            if (_context.Registrations.Find(id) == null)
            {
                return BadRequest("Registration Not Found");
            }
            return Ok(_mapper.Map<RegistrationDto>(_context.Registrations.Find(id)));
        }
        [HttpPut("{id}")]
        public IActionResult PutRegistrationById(int id, RegistrationDto dtoentity)
        {
            var modelentity = _context.Registrations.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Registration Not Found");
            }
            _mapper.Map(dtoentity, modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateRegistration(RegistrationDto dtoentity)
        {
            var modelentity = _mapper.Map<Registration>(dtoentity);
            _context.Registrations.Add(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchRegistrationById(int id, RegistrationDto dtoentity)
        {
            var modelentity = _context.Registrations.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Registration Not Found");
            }
            if (dtoentity.RegistrationDate.HasValue)
            {
                modelentity.RegistrationDate = dtoentity.RegistrationDate.Value;
            }
            if (dtoentity.Status != null)
            {
                modelentity.Status = dtoentity.Status;
            }
            if (dtoentity.EventId.HasValue)
            {
                modelentity.EventId = dtoentity.EventId.Value;
            }
            if (dtoentity.AttendeeId.HasValue)
            {
                modelentity.AttendeeId = dtoentity.AttendeeId.Value;
            }
            _context.Update(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegistrationById(int id)
        {
            if (_context.Registrations.Find(id) == null)
            {
                return BadRequest("Registration Not Found");
            }
            _context.Registrations.Remove(_context.Registrations.Find(id));
            return Ok();
        }
    }
}
