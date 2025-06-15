using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController(ITripServices _services) : ControllerBase
    {
        private readonly ITripServices _services = _services;
        // 1-Get All Trip
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<TripsDto>>>GetAllTripAsync()
        {
            var result =await _services.GetAllTripsAsync();
            return Ok(result);
        }
        //2- Get Trip By Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TripsDto>>GetTripByIDAsync(int id)
        {
            var result= await _services.GetTripByIdAsync(id);
            return Ok(result);
        }
        //3- Get Trip By Date
        [HttpGet("Date")]
        public async Task<ActionResult<TripsDto>> GetInRangeData([FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
        {
            var result= await _services.GetTripsByDateRangeAsync(startDate, endDate);
            return Ok(result);
        }
        //4- Get By Location
        [HttpGet("Location")]
        public async Task<ActionResult<TripsDto>> GetByLocation( string Location)
        {
            var result =await _services.GetTripsByLocationAsync(Location);
            return Ok(result);
        }
        //5- Get By Status
        [HttpGet("Status")]
        public async Task<ActionResult<TripsDto>> GetByStatus( string status)
        {
            var result = await _services.GetTripsByStatusAsync(status);
            return Ok(result);
        }
        //6- Get By Price Range
        [HttpGet("PriceRange")]
        public async Task<ActionResult<TripsDto>> GetByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var result = await _services.GetTripsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(result);
        }
          
        //7- Add Trip
        [HttpPost]
        public async Task<ActionResult<int>> AddTripAsync([FromBody] TripsDto trip)
        {
            if (trip == null)
            {
                return BadRequest("Trip data is null.");
            }
            var result = await _services.AddTripAsync(trip);
            return Ok(new { result });
        }
        //8- Update Trip
        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateTripAsync([FromBody] TripsDto trip, int id)
        {
            if (trip == null)
            {
                return BadRequest("Trip data is null.");
            }
            var result = await _services.UpdateTripAsync(trip, id);
            return Ok(new { result });
        }
        //9- Delete Trip
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteTripAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid trip ID.");
            }
            var result = await _services.DeleteTripAsync(id);
            if (!result)
            {
                return NotFound($"Trip with ID {id} not found.");
            }
            return Ok(new { result });
        }
    }

}
