using Microsoft.EntityFrameworkCore;
using Pharmacy_Management___Sales_API.Model;

namespace Pharmacy_Management___Sales_API.Configration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users{ set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Categpres> categpres { set; get; }
        public DbSet<Customer> customers { set; get; }
        public DbSet<Sales> sales { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categpres>().HasMany(s => s.products).WithOne(s => s.categpres).HasForeignKey(s => s.IdCategpres);
            modelBuilder.Entity<Sales>().HasMany(S => S.customers).WithOne(S => S.sales).HasForeignKey(S => S.idCustomer);
             }
    }
}
