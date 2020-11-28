using OnlineStore.Application.Common.Encryption;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Web.Services
{
    public class UserService : IUserService
    {
        public UserDTO UserDTO { get; set; }

        public UserService(UserDTO dto)
        {
            this.UserDTO = dto;
        }

        public void AddUserSession(UserDTO dTO)
        {
            HttpContext.Current.Session["UserData"] = dTO;
        }
        public void UpdateCookie(UserDTO dTO)
        {   
            HttpCookie cookie = new HttpCookie("OnlineStoreCookie");
            cookie.Value = EncryptionLib.EncryptCookie(dTO.UserToString());
            HttpContext.Current.Response.SetCookie(cookie);
            HttpContext.Current.Response.Flush();
        }

    }
}