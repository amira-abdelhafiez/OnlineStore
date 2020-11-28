using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Persistence
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext()
            :base("AppDatabaseConnection")
        {
            Database.SetInitializer<AppDbContext>(new CustomDbInitializer());
        
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<ProductCart> ProductCart { get; set; }
    }
}
