using DAW_PROJECT.BLL.Models;
using DAW_PROJECT.DAL;
using DAW_PROJECT.DAL.Entities;
using DAW_PROJECT.DAL.Infrastructure;
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
    public class EventController : ControllerBase
    {
        private readonly IAppDataAccessLayer _dal;
        public EventController(IAppDataAccessLayer dal)
        {
            _dal = dal;
        }
        [HttpPost("AddEvent")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddEvent([FromBody] EventDto newEvent)
        {
            if (ModelState.IsValid)
            {
                var @event = new Event();
                
                @event.Id = newEvent.Id;
                @event.Denumire = newEvent.Denumire;
                @event.ZiDesfasurare = newEvent.ZiDesfasurare;
                @event.Categorie = newEvent.Categorie;
                @event.Pret = newEvent.Pret;
                @event.NumarBilete = newEvent.NumarBilete;
                @event.Categorie = newEvent.Categorie;
                @event.OrganizatorId = newEvent.OrganizatorId;



               await _dal.EventRepository.AddAsysnc(@event);

                
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {

            var @event = await _dal.EventRepository.GetByIdAsync(id);
            if(@event is not null)
            {
                return Ok(@event);
            }
            return NotFound();
            
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllEvents()
        {

            var events = await _dal.EventRepository.GetAllAsync();
            if (events is not null)
            {
                return Ok(events);
            }
            return NotFound();
            
        }
        [HttpPut("Update/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateEvent(int id, Event oldEvent)
        {
            if (id != oldEvent.Id)
            {
                return BadRequest();
            }

            var newEvent = await _dal.EventRepository.GetByIdAsync(id);
            if (newEvent == null)
            {
                return NotFound();
            }

            newEvent.Denumire = oldEvent.Denumire;
            newEvent.ZiDesfasurare = oldEvent.ZiDesfasurare;
            newEvent.Pret = oldEvent.Pret;
            newEvent.NumarBilete= oldEvent.NumarBilete;
            newEvent.Categorie = oldEvent.Categorie;
            newEvent.OrganizatorId = oldEvent.OrganizatorId;


            await _dal.EventRepository.UpdateAsync(newEvent);

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _dal.EventRepository.GetByIdAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            await _dal.EventRepository.DeleteAsync(@event);


            return Ok();
        }
    }
}