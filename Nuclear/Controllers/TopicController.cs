using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Nuclear.Dtos.Post;
using Nuclear.Dtos.Topic;
using Nuclear.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nuclear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _topicService;

        public TopicController(TopicService topicService)
        {
            _topicService = topicService;
        }

        // GET api/<TopicController>/5
        /// <summary>
        /// Gets a topic by id
        /// </summary>
        /// <param name="id">The id of the topic</param>
        /// <returns>The requested topic object</returns>
        /// <response code="200">Returns the requested topic</response>
        /// <response code="404">If the topic does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var topic = _topicService.GetTopic(id);

            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        // POST api/<TopicController>
        /// <summary>
        /// Creates a new topic
        /// </summary>
        /// <param name="createTopicDto">The contents of the topic</param>
        /// <returns>The created topic object</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] CreateTopicDto createTopicDto)
        {
            var topic = await _topicService.CreateTopicAsync(createTopicDto);

            if (topic == null)
            {
                return BadRequest();
            }

            return Ok(topic);
        }

        // POST api/<TopicController>/5/reply
        /// <summary>
        /// Creates a new reply on a topic
        /// </summary>
        /// <param name="id">The id of the topic</param>
        /// <param name="createPostDto">The contents of the reply</param>
        /// <returns>The created reply object</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPost("{id}/reply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostReplyAsync(int id, [FromBody] CreatePostDto createPostDto)
        {
            var post = await _topicService.CreateReplyAsync(id, createPostDto);

            if (post == null)
            {
                return BadRequest();
            }

            return Ok(post);
        }

        // DELETE api/<TopicController>/5
        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="id">The id of the topic to be deleted</param>
        /// <response code="200">If the topic has been deleted</response>
        /// <response code="404">If the topic could not be found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _topicService.DeleteTopicAsync(id);

            if (deleted)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
