namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        { }

        public SalesContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .IsUnicode()
                .HasDefaultValue("No description");

            modelBuilder.Entity<Customer>()
               .HasKey(p => p.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
               .HasKey(p => p.StoreId);

            modelBuilder.Entity<Store>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder.Entity<Sale>()
               .HasKey(p => p.SaleId);

            modelBuilder.Entity<Sale>()
               .Property(p => p.Date)
               .IsRequired(true)
               .HasColumnType("DATETIME2")
               .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Sales)
               .WithOne(s => s.Product);
            modelBuilder.Entity<Customer>()
               .HasMany(p => p.Sales)
               .WithOne(s => s.Customer);
            modelBuilder.Entity<Store>()
               .HasMany(p => p.Sales)
               .WithOne(s => s.Store);
        }
    }
}
