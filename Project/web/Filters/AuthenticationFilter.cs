using OnlineStore.Application.Common.Encryption;
using OnlineStore.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore.Web.Filters
{
    public class AuthenticationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Check the cookie and the session
            if (filterContext.HttpContext.Session["UserData"] == null)
            {
                if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains("OnlineStoreCookie"))
                {

                    string[] tokens = EncryptionLib.DecryptCookie(filterContext.HttpContext.Request.Cookies.Get("OnlineStoreCookie").Value.ToString()).Split('&');
                    
                    if(tokens.Count() > 0)
                    {
                        UserDTO dto = new UserDTO()
                        {
                            UserId = Convert.ToInt64(tokens[0]),
                            UserName = tokens[1],
                            UserRole = new OnlineStore.Application.Roles.RoleDTO() { RoleId = Convert.ToInt32(tokens[2])},
                            Email = tokens[3]
                        };
                        filterContext.HttpContext.Session["UserData"] = dto;
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary{
                            { "controller", "Account" },
                            { "action", "Login" },
                            { "area", "" }
                        });
                    }
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{
                        { "controller", "Account" },
                        { "action", "Login" },
                        { "area", "" }
                    });
                }
                
            }

            //base.OnAuthorization(filterContext);
        }
    }
}