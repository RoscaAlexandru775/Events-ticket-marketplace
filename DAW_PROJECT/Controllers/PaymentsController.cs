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
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([FromBody] Payment payment)
        {
            if (ModelState.IsValid)
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetPayment([FromRoute] int id)
        {
            var payment = await _context.Payments.Where(x => x.Id == id).ToListAsync();
            return Ok(payment);

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllPayment()
        {
            var payment = await _context.Payments.ToListAsync();
            return Ok(payment);

        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
