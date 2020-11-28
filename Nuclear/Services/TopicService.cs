using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nuclear.Dtos.Post;
using Nuclear.Dtos.Topic;
using Nuclear.EntityFramework;
using Nuclear.EntityFramework.Models;

namespace Nuclear.Services
{
    public class TopicService
    {
        private readonly NuclearContext _context;
        private readonly IMapper _mapper;

        public TopicService(NuclearContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TopicDto GetTopic(long id)
        {
            var topic = _context.Topics
                .Include(t => t.Category)
                .Include(t => t.Posts)
                .ThenInclude(p => p.Owner)
                .FirstOrDefault(t => t.Id == id);

            return _mapper.Map<Topic, TopicDto>(topic);
        }

        public async Task<TopicDto> CreateTopicAsync(CreateTopicDto createTopicDto)
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

            return _mapper.Map<Topic, TopicDto>(topic);
        }

        public async Task<PostDto> CreateReplyAsync(long topicId, CreatePostDto createPostDto)
        {
            var post = new Post()
            {
                Topic = _context.Topics.FirstOrDefault(t => t.Id == topicId),
                Body = createPostDto.Body,
                Owner = _context.Accounts.FirstOrDefault(a => a.AccountName == "RektInator")
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return _mapper.Map<Post, PostDto>(post);
        }
    }
}
