using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<OrderItem>().
                HasKey(p => new { p.ProductId, p.OrderId });

        }
    }
}
    