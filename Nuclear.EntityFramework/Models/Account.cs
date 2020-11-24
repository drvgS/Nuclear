using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclear.EntityFramework.Models
{
    public class Account : EntityBase
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsAdministrator { get; set; }
        public List<Group> Groups { get; set; }
        public List<Post> Posts { get; set; }
    }
}
