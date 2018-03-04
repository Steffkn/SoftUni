public class Company
{
    public string Name { get; set; }

    public string Department { get; set; }

    public decimal Salary { get; set; }

    public Company(string companyName, string department, decimal salary)
    {
        this.Name = companyName;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{Name} {Department} {Salary:f2}";
    }
}
