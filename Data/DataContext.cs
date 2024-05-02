using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplicationExample.Models;

namespace WebApplicationExample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Transaction> Transaction => Set<Transaction>();
    }
}
