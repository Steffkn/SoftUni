namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        { }

        public HospitalContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }

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
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .IsUnicode();
            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .IsUnicode();
            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .IsUnicode();

            modelBuilder.Entity<Visitation>()
                .Property(p => p.Comments)
                .IsUnicode();

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Comments)
                .IsUnicode();

            modelBuilder.Entity<Medicament>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder.Entity<Visitation>()
                .HasKey(p => p.VisitationId);
            modelBuilder.Entity<Visitation>()
                .Property(p => p.PatientId)
                .IsRequired();

            modelBuilder.Entity<Visitation>()
                .Property(p => p.DoctorId)
                .IsRequired();

            modelBuilder.Entity<Medicament>()
                .HasKey(p => p.MedicamentId);
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            modelBuilder.Entity<Doctor>()
                .HasKey(p => p.DoctorId);

            modelBuilder.Entity<Doctor>()
                .Property(p => p.Name)
                .IsUnicode();
            modelBuilder.Entity<Doctor>()
                .Property(p => p.Specialty)
                .IsUnicode();
        }
    }
}
