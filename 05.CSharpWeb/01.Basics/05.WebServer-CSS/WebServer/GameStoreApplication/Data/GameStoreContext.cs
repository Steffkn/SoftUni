namespace HTTPServer.GameStoreApplication.Data
{
    using HTTPServer.GameStoreApplication.Models;
    using Microsoft.EntityFrameworkCore;

    public class GameStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connString = "Data Source=.;Database=GameStoreDb;Integrated Security=true;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Game>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Game>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(u => u.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserGames)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Game>()
                .HasMany(u => u.UserGames)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId);

            modelBuilder.Entity<UserGame>()
                .HasKey(ur => new { ur.UserId, ur.GameId });
        }
    }
}
