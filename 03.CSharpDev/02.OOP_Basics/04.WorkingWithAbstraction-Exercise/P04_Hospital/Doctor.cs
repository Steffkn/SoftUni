public class Doctor
{
    public string Name { get; set; }

    public Department Department { get; set; }

    public Doctor(string name, Department department)
    {
        this.Name = name;
        this.Department = department;
    }
}
