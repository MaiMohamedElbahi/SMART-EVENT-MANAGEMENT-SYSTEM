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
    public class OrganizersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrganizersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrganizers()
        {
            var modelentity = _context.Organizers.ToList();
            if(modelentity.Count == 0 || modelentity == null)
            {
                return BadRequest("There are no Organizers");
            } 
            return Ok(_mapper.Map<List<OrganizerDto>>(modelentity));
        }
        [HttpGet("{id}")]
        public IActionResult GetOrganizerById(int id)
        {
            if (_context.Organizers.Find(id) == null)
            {
                return BadRequest("Organizer Not Found");
            }
            return Ok(_mapper.Map<OrganizerDto>(_context.Organizers.Find(id)));
        }
        [HttpPut("{id}")]
        public IActionResult PutOrganizerById(int id, OrganizerDto dtoentity)
        {
            var modelentity = _context.Organizers.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Organizer Not Found");
            }
            _mapper.Map(dtoentity, modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateOrganizer(OrganizerDto dtoentity)
        {
            var modelentity = _mapper.Map<Organizer>(dtoentity);
            _context.Organizers.Add(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchOrganizerById(int id, OrganizerDto dtoentity)
        {
            var modelentity = _context.Organizers.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Organizer Not Found");
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
        public IActionResult DeleteOrganizerById(int id)
        {
            if (_context.Organizers.Find(id) == null)
            {
                return BadRequest("Organizer Not Found");
            }
            _context.Organizers.Remove(_context.Organizers.Find(id));
            return Ok();
        }
    }
}
