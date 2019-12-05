namespace VaporStore.Data
{
	using Microsoft.EntityFrameworkCore;
    using VaporStore.Data.Models;

    public class VaporStoreDbContext : DbContext
	{
		public VaporStoreDbContext()
		{
		}

		public VaporStoreDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Game> Games { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<GameTag> GameTags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder model)
		{
            model.Entity<Card>(card =>
            {
                card.HasOne(c => c.User).WithMany(u => u.Cards).HasForeignKey(c => c.UserId);
            });

            model.Entity<Game>(game =>
            {
                game.HasOne(g => g.Developer).WithMany(d => d.Games).HasForeignKey(g => g.DeveloperId);
                game.HasOne(g => g.Genre).WithMany(g => g.Games).HasForeignKey(g => g.GenreId);
            });

            model.Entity<GameTag>(gameTags =>
            {
                gameTags.HasKey(gt => new { gt.GameId, gt.TagId });

                gameTags.HasOne(gt => gt.Game).WithMany(g => g.GameTags).HasForeignKey(gt => gt.GameId);

                gameTags.HasOne(gt => gt.Tag).WithMany(t => t.GameTags).HasForeignKey(gt => gt.TagId);
            });

            model.Entity<Purchase>(purchase =>
            {
                purchase.HasOne(p => p.Game).WithMany(g => g.Purchases).HasForeignKey(p => p.GameId);
            });
		}
	}
}