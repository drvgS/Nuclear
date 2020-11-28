using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Dtos.Account;
using Nuclear.Dtos.Category;

namespace Nuclear.Dtos.Group
{
    public class GroupDto
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public List<AccountDto> Accounts { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
