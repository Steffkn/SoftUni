namespace Cinema.Data
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public CinemaContext() { }

        public CinemaContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Customer);

            modelBuilder.Entity<Hall>()
                .HasMany(c => c.Seats)
                .WithOne(t => t.Hall);
            modelBuilder.Entity<Hall>()
                .HasMany(c => c.Projections)
                .WithOne(t => t.Hall);

            modelBuilder.Entity<Movie>()
                .HasMany(c => c.Projections)
                .WithOne(t => t.Movie);

            modelBuilder.Entity<Projection>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Projection);


            base.OnModelCreating(modelBuilder);
        }
    }
}