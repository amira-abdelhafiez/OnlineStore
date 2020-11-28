using OnlineStore.Application.Carts;
using OnlineStore.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Web.Services
{
    public class CartService : ICartService
    {
        public CartDTO Cart { get; set; }
    }
}