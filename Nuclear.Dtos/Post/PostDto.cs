using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Dtos.Account;
using Nuclear.Dtos.Topic;

namespace Nuclear.Dtos.Post
{
    public class PostDto
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public AnonymousAccountDto Owner { get; set; }
    }
}
