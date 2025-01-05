using Microsoft.EntityFrameworkCore;
using Sales.Models;
using System.Collections.Generic;


namespace Sales.Data
{
    public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Customer> Customer { get; set; }
            public DbSet<Category> Category { get; set; }
            public DbSet<Order> Order { get; set; }
            public DbSet<Product> Product { get; set; }
    }
   
}
