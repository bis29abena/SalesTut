using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Customer> Customer { get; set; }
    }
}
