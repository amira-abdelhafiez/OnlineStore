        using System;
using System.Collections.Generic;
using System.Data.Entity;
using OnlineStore.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence
{
    public class CustomDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext dbContext)
        {
            base.Seed(dbContext);
            dbContext.Roles.Add(new Role() { RoleId = 1 , RoleName = "SystemAdmin" , AddEdit = true, Delete = true});
            dbContext.Roles.Add(new Role() { RoleId = 2, RoleName = "Consumer", AddEdit = false, Delete = false });

            dbContext.Products.Add(new Product() { ProductId = 1, ProductName = "Product 1", Price = 10, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });

            dbContext.Products.Add(new Product() { ProductId = 2, ProductName = "Product 2", Price = 10, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 3, ProductName = "Product 3", Price = 30, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 4, ProductName = "Product 4", Price = 30, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 5, ProductName = "Product 5", Price = 10.4, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 6, ProductName = "Product 6", Price = 10.7, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 7, ProductName = "Product 7", Price = 135, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 8, ProductName = "Product 8", Price = 134, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 9, ProductName = "Product 9", Price = 146, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 10, ProductName = "Product 10", Price = 1322, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 11, ProductName = "Product 11", Price = 15, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 12, ProductName = "Product 12", Price = 17, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 13, ProductName = "Product 13", Price = 44, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 14, ProductName = "Product 14", Price = 95, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 15, ProductName = "Product 15", Price = 34, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.Products.Add(new Product() { ProductId = 16, ProductName = "Product 16", Price = 23, ProductDesc = "Product1 Desc", LastUpdateDate = DateTime.Now });
            dbContext.SaveChanges();
        }
    }
}
