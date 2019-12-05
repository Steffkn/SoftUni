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
            builder.Entity<Cell>(cell =>
            {
                cell.HasOne(c => c.Department).WithMany(d => d.Cells).HasForeignKey(c => c.DepartmentId);
            });

            builder.Entity<Officer>(officer =>
            {
                officer.HasOne(o => o.Department).WithMany(d => d.Officers).HasForeignKey(o => o.DepartmentId);
            });

            builder.Entity<Mail>(mail =>
            {
                mail.HasOne(m => m.Prisoner).WithMany(p => p.Mails).HasForeignKey(m => m.PrisonerId);
            });

            builder.Entity<Prisoner>(prisoner =>
            {
                prisoner.HasOne(p => p.Cell).WithMany(c => c.Prisoners).HasForeignKey(p => p.CellId);
            });

            builder.Entity<OfficerPrisoner>(x =>
            {
                x.HasKey(of => new { of.OfficerId, of.PrisonerId });

                x.HasOne(of => of.Officer).WithMany(o => o.OfficerPrisoners).HasForeignKey(of => of.OfficerId);
                x.HasOne(of => of.Prisoner).WithMany(p => p.PrisonerOfficers).HasForeignKey(of => of.PrisonerId);
            });
		}
	}
}