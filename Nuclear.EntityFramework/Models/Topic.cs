using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear.EntityFramework.Models
{
    public class Topic : EntityBase
    {
        public string Title { get; set; }
        public Category Category { get; set; }
        public List<Post> Posts { get; set; }
    }
}
