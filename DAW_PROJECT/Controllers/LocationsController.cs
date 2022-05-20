using DAW_PROJECT.DAL;
using DAW_PROJECT.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            if (ModelState.IsValid)
            {
                await _context.Locations.AddAsync(location);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetLocation([FromRoute] int id)
        {
            var location = await _context.Locations.Where(x => x.Id == id).ToListAsync();
            return Ok(location);

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllLocation()
        {
            var location = await _context.Locations.ToListAsync();
            return Ok(location);

        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var newLocation = await _context.Locations.FindAsync(id);
            if (newLocation == null)
            {
                return NotFound();
            }

            newLocation.City = location.City;
            newLocation.Province = location.Province;
            newLocation.Zipcode = location.Zipcode;
            newLocation.Country = location.Country;
            newLocation.Address = location.Address;

           
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
