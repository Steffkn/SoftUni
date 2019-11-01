using MiniORM.App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniORM.App.Data
{
    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Employees> Employees { get; }
        public DbSet<Departments> Departments { get; }
        public DbSet<Projects> Projects { get; }
        public DbSet<EmployeesProjects> EmployeesProjects { get; }
    }
}
