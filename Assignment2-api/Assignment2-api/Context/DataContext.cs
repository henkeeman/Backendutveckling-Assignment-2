using Assignment2_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_api.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Product> ProductCatalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToContainer("ProductCatalog").HasPartitionKey(x => x.Id);
        }
    }
}
