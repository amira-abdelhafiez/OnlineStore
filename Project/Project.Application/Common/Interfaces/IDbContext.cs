using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Application.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<ProductCart> ProductCart { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbEntityEntry Entry(object entity);

    }
}
