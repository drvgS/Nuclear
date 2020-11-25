using System;
using System.Collections.Generic;
using System.Text;

namespace Nuclear.Dtos.Topic
{
    public class CreateTopicDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public long CategoryId { get; set; }
    }
}
