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
    public class OrganizersController : ControllerBase
    {
        private readonly IAppDataAccessLayer _dal;
        public OrganizersController(IAppDataAccessLayer dal)
        {
            _dal = dal;
        }

        [HttpPost("AddOrganizer")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddLocation([FromBody] Organizer organizer)
        {
            if (ModelState.IsValid)
            {

                await _dal.OrganizerRepository.AddAsysnc(organizer);
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        
        public async Task<IActionResult> GetOrganizer([FromRoute] int id)
        {
            var organizer = await _dal.OrganizerRepository.GetByIdAsync(id);
            if(organizer is not null)
            {
                return Ok(organizer);
            }
            return NotFound();

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllOrganizers()
        {
            var organizers = await _dal.OrganizerRepository.GetAllAsync();
            if (organizers is not null)
            {
                return Ok(organizers);
            }
            return NotFound();

        }
        [HttpPut("Update/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return BadRequest();
            }

            var newOrganizer = await _dal.OrganizerRepository.GetByIdAsync(id);
            if (newOrganizer == null)
            {
                return NotFound();
            }

            newOrganizer.FullName = organizer.FullName;
            newOrganizer.Email = organizer.Email;
            newOrganizer.Mobile = organizer.Mobile;


            await _dal.OrganizerRepository.UpdateAsync(newOrganizer);

            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _dal.OrganizerRepository.GetByIdAsync(id);


            if (organizer == null)
            {
                return NotFound();
            }

            await _dal.OrganizerRepository.DeleteAsync(organizer);
            

            return NoContent();
        }
    }
}
