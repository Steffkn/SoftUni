using MiniORM.App.Data;
using System;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=(localdb)\\MSSQLlocalDB;Database=MiniORM;Integrated Security=True;";
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Data.Entities.Employees
            {
                FirstName = "Asssoss",
                LastName = "Zzzzz",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Something else";

            context.SaveChanges();
        }
    }
}
