using MediatR;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Products;
using OnlineStore.Application.Products.Queries;
using OnlineStore.Web.Filters;
//using OnlineStore.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    [AuthenticationFilter]
    public class HomeController : Controller
    {
        IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: Home
        public async Task<ActionResult> Index()
        {
            List<ProductDTO> productsDTO = await mediator.Send(new GetProductsListQuery());
            
            return View(productsDTO);
        }


    }
}