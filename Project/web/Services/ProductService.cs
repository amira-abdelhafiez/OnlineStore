using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Web.Services
{
    public class ProductService : IProductService
    {
        public ProductDTO Product { get; set; }
    }
}