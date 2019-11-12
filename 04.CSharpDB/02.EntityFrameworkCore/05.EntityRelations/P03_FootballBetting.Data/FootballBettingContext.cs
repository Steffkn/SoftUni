namespace P03_FootballBetting.Data
{
    using P03_FootballBetting.Data.Configuration;
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        protected FootballBettingContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>((entity) =>
            {
                entity
                    .Property(c => c.Initials)
                    .HasColumnType("CHAR(3)");

                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId);
                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId);
                entity
                    .HasOne(t => t.Town)
                    .WithMany(town => town.Teams)
                    .HasForeignKey(t => t.TownId);

                entity
                    .HasMany(t => t.Players)
                    .WithOne(p => p.Team)
                    .HasForeignKey(p => p.TeamId);
                entity
                    .HasMany(t => t.HomeGames)
                    .WithOne(g => g.HomeTeam)
                    .HasForeignKey(g => g.HomeTeamId);
                entity
                    .HasMany(t => t.AwayGames)
                    .WithOne(g => g.AwayTeam)
                    .HasForeignKey(g => g.AwayTeamId);
            });

            modelBuilder.Entity<Color>((entity) =>
            {
                entity
                    .HasMany(e => e.PrimaryKitTeams)
                    .WithOne(team => team.PrimaryKitColor)
                    .HasForeignKey(team => team.PrimaryKitColorId);
                entity
                    .HasMany(e => e.SecondaryKitTeams)
                    .WithOne(team => team.SecondaryKitColor)
                    .HasForeignKey(team => team.SecondaryKitColorId);
            });

            modelBuilder.Entity<Country>((entity) =>
            {
                entity
                    .HasMany(e => e.Towns)
                    .WithOne(town => town.Country)
                    .HasForeignKey(town => town.CountryId);
            });

            modelBuilder.Entity<Game>((entity) =>
            {
                entity
                    .HasOne(e => e.HomeTeam)
                    .WithMany(team => team.HomeGames)
                    .HasForeignKey(game => game.HomeTeamId);
                entity
                    .HasOne(e => e.AwayTeam)
                    .WithMany(team => team.AwayGames)
                    .HasForeignKey(game => game.AwayTeamId);

                entity
                    .HasMany(e => e.PlayerStatistics)
                    .WithOne(ps => ps.Game)
                    .HasForeignKey(ps => ps.GameId);

                entity
                    .HasMany(e => e.Bets)
                    .WithOne(b => b.Game)
                    .HasForeignKey(b => b.GameId);
            });

            modelBuilder.Entity<Player>((entity) =>
            {
                entity
                    .HasOne(e => e.Team)
                    .WithMany(team => team.Players)
                    .HasForeignKey(p => p.TeamId);

                entity
                    .HasOne(e => e.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(p => p.PositionId);

                entity
                    .HasMany(e => e.PlayerStatistics)
                    .WithOne(ps => ps.Player)
                    .HasForeignKey(ps => ps.PlayerId);
            });

            modelBuilder.Entity<PlayerStatistic>((entity) =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GameId });

                entity
                    .HasOne(e => e.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);
                entity
                    .HasOne(e => e.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);
            });

            modelBuilder.Entity<Position>((entity) =>
            {
                entity
                    .HasMany(e => e.Players)
                    .WithOne(p => p.Position)
                    .HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<Town>((entity) =>
            {
                entity
                    .HasOne(e => e.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(town => town.TownId);
                entity
                    .HasMany(e => e.Teams)
                    .WithOne(team => team.Town)
                    .HasForeignKey(team => team.TownId);
            });

            modelBuilder.Entity<User>((entity) =>
            {
                entity
                    .HasMany(e => e.Bets)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<Bet>((entity) =>
            {
                entity
                    .HasOne(e => e.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);
                entity
                    .HasOne(e => e.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
