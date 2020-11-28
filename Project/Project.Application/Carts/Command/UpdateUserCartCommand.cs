using MediatR;
using OnlineStore.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Carts.Command
{
    public class UpdateUserCartCommand : IRequest<int>
    {
        public long TargetUserId { get; set; }
        public long ProductId { get; set; }
        public string Operation { get; set; }

        //// handler...
        public class UpdateUserCartCommandHandler : IRequestHandler<UpdateUserCartCommand, int>
        {
            private readonly IDbContext dbContext;
            private readonly IProductService productService;
            public UpdateUserCartCommandHandler(IDbContext dbContext
                , IProductService productService)
            {
                this.dbContext = dbContext;
                this.productService = productService;
            }

            public async Task<int> Handle(UpdateUserCartCommand request, CancellationToken cancellationToken)
            {
                var userCart = dbContext.Users.Where(u => u.UserId == request.TargetUserId).FirstOrDefault();
                var product = dbContext.Products.Where(p => p.ProductId == request.ProductId).FirstOrDefault();
                
                if(userCart != null && product != null)
                {
                    var productCart = dbContext.ProductCart.Where(pc => pc.ProductId == request.ProductId && pc.CartId == userCart.CartId);
                    if (request.Operation.Equals("Add"))
                    {
                        if(productCart.Count() > 0)
                        {
                            // Increase qunaitity
                            var currentProductCart = productCart.FirstOrDefault();
                            currentProductCart.Quantity++;
                            dbContext.Entry(currentProductCart).State = EntityState.Modified;

                        }
                        else
                        {
                            dbContext.ProductCart.Add(new Domain.Entities.ProductCart() { ProductId = request.ProductId , CartId = userCart.CartId , Quantity = 1});
                        }
                    }
                    else if (request.Operation.Equals("Remove"))
                    {
                        dbContext.ProductCart.Remove(productCart.FirstOrDefault());
                    }
                    return await dbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    return 0;
                }
                
            }
        }
    }

    
}
