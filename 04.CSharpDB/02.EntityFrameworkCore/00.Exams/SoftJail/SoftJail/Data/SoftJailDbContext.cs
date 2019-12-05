namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Prisoner>()
                .HasOne(p => p.Cell)
                .WithMany(c => c.Prisoners)
                .HasForeignKey(f => f.CellId);

            builder.Entity<Prisoner>()
                .HasMany(p => p.Mails)
                .WithOne(c => c.Prisoner)
                .HasForeignKey(f => f.PrisonerId);

            builder.Entity<OfficerPrisoner>()
                .HasOne(o => o.Officer)
                .WithMany(o => o.OfficerPrisoners)
                .HasForeignKey(f => f.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OfficerPrisoner>()
                .HasOne(o => o.Prisoner)
                .WithMany(o => o.PrisonerOfficers)
                .HasForeignKey(f => f.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OfficerPrisoner>()
               .HasKey(o => new { o.PrisonerId, o.OfficerId });

            builder.Entity<Cell>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Cells)
                .HasForeignKey(f => f.DepartmentId);
            builder.Entity<Cell>()
                .HasMany(c => c.Prisoners)
                .WithOne(p => p.Cell)
                .HasForeignKey(f => f.CellId);

            builder.Entity<Department>()
                .HasMany(c => c.Cells)
                .WithOne(p => p.Department)
                .HasForeignKey(f => f.DepartmentId);
            builder.Entity<Department>()
                .HasMany(c => c.Officers)
                .WithOne(p => p.Department)
                .HasForeignKey(f => f.DepartmentId);
        }
    }
}