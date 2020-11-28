using MediatR;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Carts.Queries
{
    public class GetUserCartQuery : IRequest<CartDTO>
    {
        public long TargetUserId { get; set; }

        public class GetUserCartQueryHandler : IRequestHandler<GetUserCartQuery, CartDTO>
        {
            IDbContext dbContext;
            ICartService cartService;
            public GetUserCartQueryHandler(IDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<CartDTO> Handle(GetUserCartQuery request, CancellationToken cancellationToken)
            {
                CartDTO cartDTO = null;
                // check user exist
                var result = dbContext.Users.Where(u => u.UserId == request.TargetUserId);
                if(result != null)
                {
                    long cartID = result.FirstOrDefault().CartId;
                    var cartData = await dbContext.Carts.FindAsync(cartID);
                    var cartProducts = dbContext.ProductCart.Where(p => p.CartId == cartID);

                    cartDTO = new CartDTO()
                    {
                        CartId = cartID,
                        Total = cartData.Total,
                        Products = new List<Products.ProductDTO>()
                    };
                    double total = 0;
                    if(cartProducts != null && cartProducts.Count() > 0)
                    {
                        foreach(var product in cartProducts)
                        {
                            cartDTO.Products.Add(new Products.ProductDTO() { 
                                ProductId= product.ProductId,
                                ProductName = product.Product.ProductName,
                                ProductDesc = product.Product.ProductDesc,
                                Price = product.Product.Price,
                                Quantity = product.Quantity
                            });
                            total += product.Quantity * product.Product.Price;
                        }
                    }
                    cartDTO.Total = total;
                }
                return cartDTO;
            }
        }
    }
}
