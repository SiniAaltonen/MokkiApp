using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;
using MokkiApp.Services;

namespace MokkiApp.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetAsync(int id)
        {
            var category = await _categoryService.GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory([FromRoute]int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var theCategory = await _categoryService.UpdateCategory(id, category);
                return Ok(theCategory);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var theCategory = await _categoryService.AddCategory(category);
            return Ok(theCategory);
        }

        // DELETE: api/Categories/
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory([FromRoute] int id)
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
