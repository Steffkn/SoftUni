using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var departments = new Dictionary<string, List<Employee>>();
        string input = string.Empty;
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            var tockens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string department = tockens[3];
            var newEmployee = new Employee(tockens[0], decimal.Parse(tockens[1]), tockens[2], department);

            if (tockens.Length == 6)
            {
                newEmployee.Email = tockens[4];
                newEmployee.Age = sbyte.Parse(tockens[5]);
            }
            else if (tockens.Length == 5)
            {
                sbyte age;
                if (sbyte.TryParse(tockens[4], out age))
                {
                    newEmployee.Age = age;
                }
                else
                {
                    newEmployee.Email = tockens[4];
                }
            }

            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<Employee>());
            }

            departments[department].Add(newEmployee);
        }

        // get the department with highest average salary
        var higestAvgSalaryDepartment = departments
            .Select(s => new KeyValuePair<string, decimal>(s.Key, s.Value.Average(x => x.Salary)))
            .OrderByDescending(s => s.Value)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {higestAvgSalaryDepartment.Key}");
        foreach (var employee in departments[higestAvgSalaryDepartment.Key]
            .OrderByDescending(s => s.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}
