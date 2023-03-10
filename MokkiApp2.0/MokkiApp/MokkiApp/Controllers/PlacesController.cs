using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Services;

namespace MokkiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService ?? throw new ArgumentNullException(nameof(placeService));
        }

        // GET: api/Places
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetAllPlaces()
        {
            return Ok(await _placeService.GetAllPlacesAsync());
        }

        // GET: api/Places/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceAsync(int id)
        {
            var place = await _placeService.GetPlaceAsync(id);

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        // PUT: api/Places/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlace(int id, Place place)
        {
            if (id != place.Id)
            {
                return BadRequest();
            }
            try
            {
                var thePlace = await _placeService.UpdatePlace(id, place);
                return Ok(thePlace);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Places
        [HttpPost]
        public async Task<ActionResult<Place>> AddPlace(Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var thePlace = await _placeService.AddPlace(place);
            return Ok(thePlace);
        }
    }

    //// DELETE: api/Places/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeletePlace(int id)
    //{
    //    var place = await _context.Places.FindAsync(id);
    //    if (place == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Places.Remove(place);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    //private bool PlaceExists(int id)
    //{
    //    return _context.Places.Any(e => e.Id == id);
    //}
}

