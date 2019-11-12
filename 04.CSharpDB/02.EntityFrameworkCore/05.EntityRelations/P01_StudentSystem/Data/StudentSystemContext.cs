using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        protected StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>((entity) =>
            {
                entity
                    .Property(c => c.Name)
                    .IsUnicode(true);

                entity
                    .Property(c => c.Description)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity
                    .HasMany(c => c.StudentsEnrolled)
                    .WithOne(sc => sc.Course)
                    .HasForeignKey(sc => sc.CourseId);

                entity
                    .HasMany(c => c.Resources)
                    .WithOne(r => r.Course)
                    .HasForeignKey(r => r.CourseId);

                entity
                    .HasMany(c => c.HomeworkSubmissions)
                    .WithOne(h => h.Course)
                    .HasForeignKey(h=>h.CourseId);
            });

            modelBuilder.Entity<Student>((entity) =>
            {
                entity
                    .Property(e => e.Name)
                    .IsUnicode(true);

                entity
                    .Property(e => e.PhoneNumber)
                    .HasColumnType("CHAR(10)")
                    .IsRequired(false);

                entity
                    .Property(e => e.RegisteredOn)
                    .HasDefaultValueSql("GETDATE()")
                    .IsRequired(true);

                entity
                    .HasMany(e=>e.CourseEnrollments)
                    .WithOne(sc => sc.Student)
                    .HasForeignKey(sc => sc.StudentId);

                entity
                    .HasMany(c => c.HomeworkSubmissions)
                    .WithOne(h => h.Student)
                    .HasForeignKey(h => h.StudentId);
            });

            modelBuilder.Entity<Resource>((entity) =>
            {
                entity
                    .Property(e => e.Name)
                    .IsUnicode(true);

                entity
                    .Property(e => e.Url)
                    .IsUnicode(false)
                    .IsRequired();

                entity
                    .HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(x => x.CourseId);
            });

            modelBuilder.Entity<Homework> ((entity) =>
            {
                entity
                    .Property(e => e.Content)
                    .IsUnicode(false);

                entity
                    .HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

                entity
                    .HasOne(h => h.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse> ((entity) =>
            {
                entity
                    .HasKey((e) => new { e.StudentId, e.CourseId });

                entity
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);
                entity
                    .HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
