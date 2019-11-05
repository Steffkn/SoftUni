using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Models.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        private const string projectDateFormat = "M/d/yyyy h:mm:ss tt";

        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            var result = GetEmployeesInPeriod(context);
            Console.WriteLine(result);
        }

        // Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select((e) => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select((e) => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select((e) => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Models.Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            var nakov = context.Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            nakov.Address = newAddress;
            context.Addresses.Add(newAddress);
            context.SaveChanges();

            var employeesAddresses = context.Employees
                .Select(e => new
                {
                    e.Address.AddressText,
                    e.Address.AddressId
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10);

            StringBuilder sb = new StringBuilder();
            foreach (var employeeAddress in employeesAddresses)
            {
                sb.AppendLine(employeeAddress.AddressText);
            }

            return sb.ToString().Trim();
        }

        // Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Count > 0)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ej => ej.Project)
                    .Where(proj =>
                            proj.StartDate.Year >= 2001
                            && proj.StartDate.Year <= 2003)
                })
                .Take(10);

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} – Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine(string.Format("--{0} - {1} – {2}", project.Name,
                        project.StartDate.ToString(projectDateFormat, CultureInfo.InvariantCulture),
                        project.EndDate.HasValue ?
                            project.EndDate.Value.ToString(projectDateFormat, CultureInfo.InvariantCulture)
                            : "not finished"));
                }
            }

            return sb.ToString().Trim();
        }
    }
}
