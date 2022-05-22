using DAW_PROJECT.DAL;
using DAW_PROJECT.DAL.Entities;
using DAW_PROJECT.DAL.Infrastructure.Abstraction;
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
    public class PaymentsController : ControllerBase
    {
        private readonly IAppDataAccessLayer _dal;
        public PaymentsController(IAppDataAccessLayer dal)
        {
            _dal = dal;
        }
        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([FromBody] Payment payment)
        {
            if (ModelState.IsValid)
            {
                await _dal.PaymentRepository.AddAsysnc(payment);
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetPayment([FromRoute] int id)
        {
            var payment = await _dal.PaymentRepository.GetByIdAsync(id);
            if (payment is not null)
            {
                return Ok(payment);
            }

            return NotFound();
        }
        [HttpGet("Get")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAllPayment()
        {
            var payment = await _dal.PaymentRepository.GetAllAsync();
            if (payment is not null)
            {
                return Ok(payment);
            }

            return NotFound();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _dal.PaymentRepository.GetByIdAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            await _dal.PaymentRepository.DeleteAsync(payment);
            

            return NoContent();
        }

    }
}
