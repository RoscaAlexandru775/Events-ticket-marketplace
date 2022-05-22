using DAW_PROJECT.DAL;
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

    public class LinqController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LinqController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("Where/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {

            var results = await _context.Events.Where(x => x.Id == id).ToListAsync();
            if (results == null)
                return NotFound();
            return Ok(results);

        }
        [HttpGet("GroupBy")]
        public async Task<IActionResult> GroupByLinq()
        {


            var results =  _context.Events.Include(x => x.OrganizerEvent).AsEnumerable().GroupBy(x => x.Categorie).ToList();
            return Ok(results);

        }
        [HttpGet("Join")]
        public async Task<IActionResult> JoinLinq()
        {
            var results = await _context.Events.Join(
                                                    _context.Organizers,
                                                    p1 => p1.OrganizatorId,
                                                    p2 => p2.Id,
                                                    (p1, p2) => new { EventName = p1.Denumire, OrganizerName = p2.FullName }).ToListAsync();
            return Ok(results);
        }
        [HttpGet("Include")]
        public async Task<IActionResult> Includeinq()
        {
          
            var results = await _context.Events.Include(x => x.OrganizerEvent).ToListAsync();
            return Ok(results);
        }

    }
    }
