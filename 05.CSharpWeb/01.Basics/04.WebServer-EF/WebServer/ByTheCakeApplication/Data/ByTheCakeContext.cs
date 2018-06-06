namespace HTTPServer.ByTheCakeApplication.Data
{
    using HTTPServer.ByTheCakeApplication.Models;
    using Microsoft.EntityFrameworkCore;

    public class ByTheCakeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Data Source=.;Database=ByTheCakeDb;Integrated Security=true;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(product => product.Orders)
                .WithOne(order => order.Product)
                .HasForeignKey(po => po.ProductId);

            modelBuilder
                .Entity<Order>()
                .HasMany(order => order.Products)
                .WithOne(product => product.Order)
                .HasForeignKey(po => po.OrderId);

            modelBuilder
                .Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder
                .Entity<User>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
