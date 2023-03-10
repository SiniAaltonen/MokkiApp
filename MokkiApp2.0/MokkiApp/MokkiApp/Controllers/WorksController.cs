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
    public class WorksController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorksController(IWorkService workService)
        {
            _workService = workService ?? throw new ArgumentNullException(nameof(workService));
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetAllWorksAsync()
        {
            return Ok(await _workService.GetAllWorksAsync());
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWorkAsync(int id)
        {
            var work = await _workService.GetWorkAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Works/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWork(int id, Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var theWork = await _workService.UpdateWork(id, work);
                return Ok(theWork);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Works
        [HttpPost]
        public async Task<ActionResult<Work>> AddWork(Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var theWork = await _workService.AddWork(work);
            return Ok(theWork);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWork(int id)
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
