﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeisterMask.Data;

namespace TeisterMask.Migrations
{
    [DbContext(typeof(TeisterMaskContext))]
    partial class TeisterMaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeisterMask.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TeisterMask.Data.Models.EmployeeTask", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("TaskId");

                    b.HasKey("EmployeeId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("EmployeesTasks");
                });

            modelBuilder.Entity("TeisterMask.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("OpenDate");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TeisterMask.Data.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("ExecutionType");

                    b.Property<int>("LabelType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("OpenDate");

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TeisterMask.Data.Models.EmployeeTask", b =>
                {
                    b.HasOne("TeisterMask.Data.Models.Employee", "Employee")
                        .WithMany("EmployeesTasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TeisterMask.Data.Models.Task", "Task")
                        .WithMany("EmployeesTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeisterMask.Data.Models.Task", b =>
                {
                    b.HasOne("TeisterMask.Data.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
