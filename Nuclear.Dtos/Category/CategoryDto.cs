using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Dtos.Group;
using Nuclear.Dtos.Topic;

namespace Nuclear.Dtos.Category
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TopicDto> Topics { get; set; }
        public bool IsPublic { get; set; }
        public List<GroupDto> Groups { get; set; }
    }
}
