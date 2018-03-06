public class Person
{
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; }

    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }

    public void IncreaseSalary(decimal bonus)
    {
        if (this.Age >= 30)
        {
            this.Salary += this.Salary * bonus / 100;
        }
        else
        {
            this.Salary += this.Salary * bonus / 200;
        }
    }
}