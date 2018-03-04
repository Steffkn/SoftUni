using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string name;

    private decimal salary;

    private string position;

    private string deparment;

    private string email;

    private sbyte age;

    public Employee(string name, decimal salary, string position, string deparment, string email = "n/a", sbyte age = -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Deparment = deparment;
        this.Email = email;
        this.Age = age;
    }

    public string Name { get => this.name; set => this.name = value; }

    public decimal Salary { get => this.salary; set => this.salary = value; }

    public string Position { get => position; set => position = value; }

    public string Deparment { get => deparment; set => deparment = value; }

    public string Email { get => email; set => email = value; }

    public sbyte Age { get => age; set => age = value; }
}
