using Microsoft.EntityFrameworkCore;
using StoreManager_4lab.Models;

namespace StoreManager_4lab.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=store.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
