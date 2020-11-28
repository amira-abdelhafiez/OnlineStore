using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Web.ViewModels
{
    public class ProductVM
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string Description { get; set; }
    }
}