using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear.EntityFramework.Models
{
    public class Group : EntityBase
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Category> Categories { get; set; }
    }
}
