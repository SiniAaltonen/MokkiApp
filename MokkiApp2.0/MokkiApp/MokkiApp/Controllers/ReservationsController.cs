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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservationsAsync()
        {
            return Ok(await _reservationService.GetAllReservationsAsync());
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationAsync(int id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReservation(int id, Reservation reservation)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var theReservation = await _reservationService.UpdateReservation(id, reservation);
                return Ok(theReservation);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> AddReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var theReservation = await _reservationService.AddReservation(reservation);
            return Ok(theReservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
