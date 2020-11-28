using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Application.Carts.Queries;
using System.Threading.Tasks;
using OnlineStore.Application.Carts;
using OnlineStore.Application.Users;
using OnlineStore.Application.Carts.Command;
using OnlineStore.Web.Filters;

namespace web.Controllers
{
    [AuthenticationFilter]
    public class CartController : Controller
    {
        IMediator mediator;
        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<ActionResult> Index()
        {
            long currentUserId = ((UserDTO)Session["UserData"]).UserId;
            CartDTO userCart = await mediator.Send(new GetUserCartQuery() { TargetUserId = currentUserId});
            return View(userCart);
        }
        [HttpGet]
        public async Task<ActionResult> AddToUserCart(long ProductId)
        {
            try
            {
                long currentUserId = ((UserDTO)Session["UserData"]).UserId;

                int status = await mediator.Send(new UpdateUserCartCommand() { Operation = "Add", ProductId = ProductId, TargetUserId = currentUserId });
                if (status == 1)
                {
                    
                }
                else
                {

                }
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("Index", "Cart");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteFromUserCart(long ProductId)
        {
            try
            {
                long currentUserId = ((UserDTO)Session["UserData"]).UserId;

                int status = await mediator.Send(new UpdateUserCartCommand() { Operation = "Remove", ProductId = ProductId, TargetUserId = currentUserId });
                if (status == 1)
                {

                }
                else
                {

                }
            }
            catch (Exception e) { }

            return RedirectToAction("Index", "Cart");
        }
    }
}