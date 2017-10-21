namespace _10.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StudentGroups
    {
        static void Main()
        {
            var towns = ReadTownsAndStudents();

            var groups = GenerateGroups(towns);

            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

            foreach (var group in groups.OrderBy(g => g.Town.Name))
            {
                Console.WriteLine($"{group.Town.Name} => {String.Join(", ", group.Students.Select(s=>s.Email))}");
            }
        }

        private static List<Group> GenerateGroups(List<Town> towns)
        {
            List<Group> result = new List<Group>();

            foreach (var town in towns)
            {
                var group = new Group();
                group.Students = new List<Student>();
                group.Town = town;

                foreach (var student in town.Students.OrderBy(s => s.RegistrationDate).ThenBy(s => s.Name).ThenBy(s => s.Email))
                {
                    if (group.Students.Count < town.SeatsCount)
                    {
                        group.Students.Add(student);
                    }
                    else
                    {
                        result.Add(group);
                        group = new Group();
                        group.Students = new List<Student>();
                        group.Town = town;
                        group.Students.Add(student);
                    }
                }

                result.Add(group);
            }

            return result;
        }

        public static List<Town> ReadTownsAndStudents()
        {
            List<Town> result = new List<Town>();

            var input = Console.ReadLine();

            Town currentTown;

            while (!input.Equals("End"))
            {
                if (input.Contains("=>"))
                {
                    var args = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string townName = args[0].Trim();
                    string[] steatStr = args[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int seats = int.Parse(steatStr[0]);

                    if (!result.Any(t => t.Name == townName))
                    {
                        currentTown = new Town(townName, seats);
                        result.Add(currentTown);
                    }
                }
                else
                {
                    var args = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    var name = args[0];
                    var email = args[1];
                    DateTime regDate = DateTime.ParseExact(args[2], "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    result.Last().Students.Add(new Student(name, email, regDate));
                }

                input = Console.ReadLine();
            }

            return result;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Student(string name, string email, DateTime dateTime)
        {
            this.Name = name;
            this.Email = email;
            this.RegistrationDate = dateTime;
        }
    }

    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }

        public Town(string name, int seatsCount)
        {
            this.Name = name;
            this.SeatsCount = seatsCount;
            this.Students = new List<Student>();
        }
    }

    public class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
