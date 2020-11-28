using OnlineStore.Application.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Users
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public RoleDTO UserRole { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }

        public string UserToString()
        {
            string str = this.UserId.ToString() + "&" + this.UserName + "&" + UserRole.RoleId + "&" + this.Email;
            return str;
        }
    }
}
