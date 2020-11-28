using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Nuclear.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nuclear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>The requested categories</returns>
        /// <response code="200">Returns the requested categories</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <returns>The requested category</returns>
        /// <response code="200">Returns the requested category object</response>
        /// <response code="404">If the category does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // GET api/<CategoryController>/5/topics
        /// <summary>
        /// Gets the topics for the specified category
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <returns>The requested topics</returns>
        /// <response code="200">Returns the requested topics for the category</response>
        /// <response code="404">If the category does not exist</response>
        [HttpGet("{id}/topics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTopics(int id)
        {
            var category = _categoryService.GetTopicsForCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
