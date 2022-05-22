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
    public class LocationsController : ControllerBase
    {
        private readonly IAppDataAccessLayer _dal;
        public LocationsController(IAppDataAccessLayer dal)
        {
            _dal = dal;
        }
        [HttpPost("AddLocation")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            if (ModelState.IsValid)
            {
                await _dal.LocationRepository.AddAsysnc(location);
                
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetLocation([FromRoute] int id)
        {
            var location = await _dal.LocationRepository.GetByIdAsync(id);
            if (location is not null)
            {
                return Ok(location);
            }
            return NotFound();

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllLocation()
        {
            var locations = await _dal.LocationRepository.GetAllAsync();
            if (locations is not null)
            {
                return Ok(locations);
            }
            return NotFound();
        }
        [HttpPut("Update/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var newLocation = await _dal.LocationRepository.GetByIdAsync(id);
            if (newLocation == null)
            {
                return NotFound();
            }

            newLocation.City = location.City;
            newLocation.Province = location.Province;
            newLocation.Zipcode = location.Zipcode;
            newLocation.Country = location.Country;
            newLocation.Address = location.Address;


            await _dal.LocationRepository.UpdateAsync(newLocation);

            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _dal.LocationRepository.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            await _dal.LocationRepository.DeleteAsync(location);

            return NoContent();
        }
    }
}
