namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }

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
            builder.Entity<Project>(entity =>
            {
                entity.HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);
            });

            builder.Entity<Employee>(entity =>
            {
                entity.HasMany(e => e.EmployeesTasks)
                .WithOne(et => et.Employee)
                .HasForeignKey(et => et.EmployeeId);
            });

            builder.Entity<Task>(entity =>
            {
                entity.HasMany(e => e.EmployeesTasks)
                .WithOne(et => et.Task)
                .HasForeignKey(et => et.TaskId);
            });

            builder.Entity<EmployeeTask>()
                .HasKey(et => new { et.EmployeeId, et.TaskId });
        }
    }
}