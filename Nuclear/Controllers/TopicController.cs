using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateTopicDto createTopicDto)
        {
            var topic = await _topicService.CreateTopicAsync(createTopicDto);

            if (topic == null)
            {
                return BadRequest();
            }

            return Ok(topic);
        }

        // PUT api/<TopicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // POST api/<TopicController>/5/reply
        [HttpPost("{id}/reply")]
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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
