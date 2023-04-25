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

    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService ?? throw new ArgumentNullException(nameof(workerService));
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return await _workerService.GetAllWorkersAsync();
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorkerAsync(int id)
        {
            var worker = await _workerService.GetWorkerAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // PUT: api/Workers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorker(int id, Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var theWorker = await _workerService.UpdateWorker(id, worker);
                return Ok(theWorker);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST: api/Workers
        [HttpPost]
        public async Task<ActionResult<Worker>> AddWorker(Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var theWorker = await _workerService.AddWorker(worker);
            return Ok(theWorker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker([FromRoute] int id)
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
        }
    }
}
