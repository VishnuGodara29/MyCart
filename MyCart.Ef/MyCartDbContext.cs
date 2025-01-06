using Microsoft.EntityFrameworkCore;
using MyCart.Domain.Carts;
using MyCart.Domain.Categorys;
using MyCart.Domain.Orders;
using MyCart.Domain.Products;
using MyCart.Domain.Users;

namespace MyCart.Ef
{
    public class MyCartDbContext : DbContext
    {
        public MyCartDbContext(DbContextOptions<MyCartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<usar> Users { get; set; }


    }
}

