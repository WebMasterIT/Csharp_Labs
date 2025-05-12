using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Models;

namespace StoreManagerApi.Data
{
    // Класс контекста базы данных, используемый Entity Framework Core
    public class StoreDbContext : DbContext
    {
        // Конструктор с передачей параметров подключения
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        // Наборы данных (таблицы)
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        // Конфигурация модели при создании схемы базы данных
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)     // Один заказ содержит много позиций
                .WithOne(oi => oi.Order)       // Обратная навигация
                .HasForeignKey(oi => oi.OrderId)        // Указан внешний ключ
                .OnDelete(DeleteBehavior.Cascade);        // При удалении заказа — удалить все позиции

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)      // Каждая позиция ссылается на один продукт
                .WithMany()                       // Один продукт может быть в нескольких позициях
                .HasForeignKey(oi => oi.ProductId)   // Внешний ключ на продукт
                .OnDelete(DeleteBehavior.Restrict);  // Запретить удаление продукта, если он в заказах
        }
    }
}
