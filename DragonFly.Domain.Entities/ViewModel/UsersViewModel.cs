using System;
using System.Collections.Generic;
using System.Text;

namespace DragonFly.Domain.Entities.ViewModel
{
    public class UsersViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public byte AdminType { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
