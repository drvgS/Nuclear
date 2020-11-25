using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nuclear.EntityFramework;

namespace Nuclear.Services
{
    public class AccountService
    {
        private readonly NuclearContext _context;

        public AccountService(NuclearContext context)
        {
            _context = context;
        }
    }
}
