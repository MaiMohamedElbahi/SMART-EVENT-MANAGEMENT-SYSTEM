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
    public class VenuesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VenuesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllVenues()
        {
            var modelentity = _context.Venues.ToList();
            if(modelentity.Count == 0 || modelentity == null)
            {
                return BadRequest("There are no Venues");
            } 
            return Ok(_mapper.Map<List<VenueDto>>(modelentity));
        }
        [HttpGet("{id}")]
        public IActionResult GetVenueById(int id)
        {
            if (_context.Venues.Find(id) == null)
            {
                return BadRequest("Venue Not Found");
            }
            return Ok(_mapper.Map<VenueDto>(_context.Venues.Find(id)));
        }
        [HttpPut("{id}")]
        public IActionResult PutVenueById(int id, VenueDto dtoentity)
        {
            var modelentity = _context.Venues.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Venue Not Found");
            }
            _mapper.Map(dtoentity, modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateVenue(VenueDto dtoentity)
        {
            var modelentity = _mapper.Map<Venue>(dtoentity);
            _context.Venues.Add(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchVenueById(int id, VenueDto dtoentity)
        {
            var modelentity = _context.Venues.Find(id);
            if (modelentity == null)
            {
                return BadRequest("Venue Not Found");
            }
            if (dtoentity.Name != null)
            {
                modelentity.Name = dtoentity.Name;
            }
            if (dtoentity.Location != null)
            {
                modelentity.Location = dtoentity.Location;
            }
            if (dtoentity.Capacity.HasValue)
            {
                modelentity.Capacity = dtoentity.Capacity.Value;
            }

            _context.Update(modelentity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVenueById(int id)
        {
            if (_context.Venues.Find(id) == null)
            {
                return BadRequest("Venue Not Found");
            }
            _context.Venues.Remove(_context.Venues.Find(id));
            return Ok();
        }
    }
}
