using OnlineStore.Web.ViewModels;
using OnlineStore.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediatR;
using OnlineStore.Application.Users.Command;
using System.Threading.Tasks;
using OnlineStore.Web.Filters;

namespace web.Controllers
{
    public class AccountController : Controller
    {
        IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(loginVM model)
        {
            // operation of login.....
            if (ModelState.IsValid)
            {
                try
                {
                    UserDTO dto = new UserDTO()
                    {
                        UserName = model.UserName,
                        Password = model.Password
                        
                    };
                    long status = await mediator.Send(new LoginUserCommand() { User = dto , RemeberMe = model.RememberMe});
                    if(status > 0)
                    {
                        //Response.ClearHeaders();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Incorrect User name or password.";
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {

                UserDTO dto = new UserDTO()
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Email = model.Email
                };
                try
                {
                    int status = await mediator.Send(new RegisterUserCommand() { User = dto });
                }
                catch(Exception) { }
                ViewBag.Message = "SuccessFul Register , Please Check your mail";
            }
            return View("RegisterResult");
        }

        [AuthenticationFilter]
        public ActionResult Logout()
        {
            // Clear all sessions and cookies

            return View();
        }

    }
}