using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Dtos.Group;
using Nuclear.Dtos.Post;

namespace Nuclear.Dtos.Account
{
    public class AccountDto
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsAdministrator { get; set; }
        public List<GroupDto> Groups { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}
