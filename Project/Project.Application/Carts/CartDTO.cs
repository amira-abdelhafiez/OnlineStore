using OnlineStore.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Carts
{
    public class CartDTO
    {
        public long CartId { set; get; }

        public List<ProductDTO> Products { get; set; }
        public double Total { get; set; }
    }
}
