using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TopicController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTopicDto createTopicDto)
        {
            await _topicService.CreateTopicAsync(createTopicDto);
            return Ok();
        }

        // PUT api/<TopicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TopicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
