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
    public class OrganizersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrganizersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddOrganizer")]
        public async Task<IActionResult> AddLocation([FromBody] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                await _context.Organizers.AddAsync(organizer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetOrganizer([FromRoute] int id)
        {
            var organizer = await _context.Organizers.Where(x => x.Id == id).ToListAsync();
            return Ok(organizer);

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllOrganizers()
        {
            var organizers = await _context.Organizers.ToListAsync();
            return Ok(organizers);

        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return BadRequest();
            }

            var newOrganizer = await _context.Organizers.FindAsync(id);
            if (newOrganizer == null)
            {
                return NotFound();
            }

            newOrganizer.FullName = organizer.FullName;
            newOrganizer.Email = organizer.Email;
            newOrganizer.Mobile = organizer.Mobile;


            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id);

            if (organizer == null)
            {
                return NotFound();
            }

            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
