using MediatR;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Products.Queries
{
    public class GetProductsListQuery : IRequest<List<ProductDTO>>
    {
        public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductDTO>>
        {
            IDbContext dbContext;
            IProductService productService;
            public GetProductsListQueryHandler(IDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<List<ProductDTO>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
            {
                List<ProductDTO> productDTOs = new List<ProductDTO>();

                var result = dbContext.Products.ToList();
                
                if (result != null && result.Count() > 0)
                {
                    ProductDTO temp;
                    foreach(var prod in result)
                    {
                        temp = new ProductDTO()
                        {
                            ProductId = prod.ProductId,
                            ProductName = prod.ProductName,
                            ProductDesc = prod.ProductDesc , 
                            Price = prod.Price
                        };
                        productDTOs.Add(temp);
                    }
                }

                return productDTOs;
            }



        }
    }
}
