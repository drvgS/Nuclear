using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear.EntityFramework.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Topic> Topics { get; set; }
        public bool IsPublic { get; set; }
        public List<Group> Groups { get; set; }
    }
}
