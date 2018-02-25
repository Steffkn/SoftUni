using System.Collections.Generic;

public class Room
{
    public List<Patient> Patients { get; set; }

    public Room()
    {
        this.Patients = new List<Patient>(3);
    }

    public bool HasSpace()
    {
        return Patients.Count < 3;
    }

    public bool AddPatient(Patient person)
    {
        if (this.HasSpace())
        {
            person.Room = this;
            this.Patients.Add(person);
            return true;
        }

        return false;
    }
}
