using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nuclear.Dtos.Topic;
using Nuclear.EntityFramework;
using Nuclear.EntityFramework.Models;

namespace Nuclear.Services
{
    public class TopicService
    {
        private readonly NuclearContext _context;

        public TopicService(NuclearContext context)
        {
            _context = context;
        }

        public async Task CreateTopicAsync(CreateTopicDto createTopicDto)
        {
            var topic = new Topic()
            {
                Title = createTopicDto.Title,
                Category = _context.Categories.FirstOrDefault(c => c.Id == createTopicDto.CategoryId),
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Body = createTopicDto.Body,
                        Owner = _context.Accounts.FirstOrDefault(a => a.AccountName == "RektInator")
                    }
                }
            };

            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }
    }
}
