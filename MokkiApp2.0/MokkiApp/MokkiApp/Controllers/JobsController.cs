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
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobsAsync()
        {
            return Ok(await _jobService.GetAllJobsAsync());
        }

        //GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobAsync(int id)
        {
            var job = await _jobService.GetJobAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/Jobs/
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJob(int id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var theJob = await _jobService.UpdateJob(id, job);
                return Ok(theJob);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult<Job>> AddJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var theJob = await _jobService.AddJob(job);
            return Ok(theJob);
        }

        // DELETE: api/Jobs/
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJob([FromRoute] int id)
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
