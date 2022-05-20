using DAW_PROJECT.DAL;
using DAW_PROJECT.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent([FromBody] Event newEvent)
        {
            if (ModelState.IsValid)
            {
                await _context.Events.AddAsync(newEvent);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var location = await _context.Events.Where(x => x.Id == id).ToListAsync();
            return Ok(location);

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);

        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event oldEvent)
        {
            if (id != oldEvent.Id)
            {
                return BadRequest();
            }

            var newEvent = await _context.Events.FindAsync(id);
            if (newEvent == null)
            {
                return NotFound();
            }

            newEvent.Denumire = oldEvent.Denumire;
            newEvent.ZiDesfasurare = oldEvent.ZiDesfasurare;
            newEvent.LocatieEventId = oldEvent.LocatieEventId;
            newEvent.Pret = oldEvent.Pret;
            newEvent.NumarBilete= oldEvent.NumarBilete;
            newEvent.Categorie = oldEvent.Categorie;
            newEvent.OrganizatorId = oldEvent.OrganizatorId;


            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var event2 = await _context.Events.FindAsync(id);

            if (event2 == null)
            {
                return NotFound();
            }

            _context.Events.Remove(event2);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}