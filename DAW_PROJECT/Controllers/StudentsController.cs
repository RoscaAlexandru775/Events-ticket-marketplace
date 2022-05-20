using DAW_PROJECT.DAL;
using DAW_PROJECT.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddStudent")]

        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
            
            
            //return NoContent();
        }
    }
}
