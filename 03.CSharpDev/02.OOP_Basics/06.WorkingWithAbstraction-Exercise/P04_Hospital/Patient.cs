public class Patient
{
    public string Name { get; set; }

    public Doctor Doctor { get; set; }

    public Room Room { get; set; }

    public Patient(string name, Doctor doctor)
    {
        this.Name = name;
        this.Doctor = doctor;
    }
}
