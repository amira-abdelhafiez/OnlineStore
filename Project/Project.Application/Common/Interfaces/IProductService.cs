using OnlineStore.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Common.Interfaces
{
    public interface IProductService
    {
        ProductDTO Product { get; set; }
    }
}
