using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, Doctor>();
            var patients = new Dictionary<string, Patient>();
            var departments = new Dictionary<string, Department>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] commandArgs = command.Split();
                var departament = commandArgs[0];
                var patient = commandArgs[3];
                var docFullName = $"{commandArgs[1]} {commandArgs[2]}";

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new Department(departament);
                }

                if (!doctors.ContainsKey(docFullName))
                {
                    doctors[docFullName] = new Doctor(docFullName, departments[departament]);
                }

                if (!patients.ContainsKey(patient))
                {
                    patients[patient] = new Patient(patient, doctors[docFullName]);
                }

                var room = departments[departament].GetFreeRoom();
                if (room != null)
                {
                    departments[departament].AddPatient(room, patients[patient]);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                if (departments.ContainsKey(commandArgs[0]))
                {
                    var departmentName = commandArgs[0];

                    if (commandArgs.Length == 1)
                    {
                        foreach (var patient in departments[departmentName]
                            .Rooms
                            .SelectMany(x => x.Patients))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        var roomNumber = int.Parse(commandArgs[1]) - 1;

                        foreach (var patient in departments[departmentName]
                            .Rooms[roomNumber]
                            .Patients
                            .OrderBy(p => p.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }
                else
                {
                    var docName = $"{commandArgs[0]} {commandArgs[1]}";

                    var aaa = patients
                        .Where(p => p.Value.Doctor.Name == docName);
                    foreach (var patient in aaa
                        .OrderBy(p => p.Key))
                    {
                        Console.WriteLine(patient.Key);
                    }
                }
            }
        }
    }
}
