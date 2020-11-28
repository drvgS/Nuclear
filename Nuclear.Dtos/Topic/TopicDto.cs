using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Dtos.Category;
using Nuclear.Dtos.Post;

namespace Nuclear.Dtos.Topic
{
    public class TopicDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}
