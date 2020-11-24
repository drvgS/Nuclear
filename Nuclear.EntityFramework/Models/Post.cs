using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear.EntityFramework.Models
{
    public class Post : EntityBase
    {
        public string Body { get; set; }
        public Account Owner { get; set; }
        public Topic Topic { get; set; }
    }
}
