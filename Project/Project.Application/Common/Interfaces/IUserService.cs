using OnlineStore.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Common.Interfaces
{
    public interface IUserService
    {
        UserDTO UserDTO { get; set; }

        void UpdateCookie(UserDTO dTO);

        void AddUserSession(UserDTO dTO);
    }
}
