namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class MentorGroup
    {
        private const string Format = "dd/MM/yyyy";

        static void Main()
        {
            var input = Console.ReadLine();
            var students = new SortedDictionary<string, Student>();

            while (input != "end of dates")
            {
                var inputs = input.Split();
                var name = inputs[0];
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new Student());
                }

                if (inputs.Length > 1)
                {
                    var dates = inputs[1]
                      .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(x => DateTime.ParseExact(x, Format, CultureInfo.InvariantCulture))
                      .ToList();

                    students[name].Attends.AddRange(dates);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of comments")
            {
                var inputs = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var name = inputs[0];

                var comment = inputs[1];

                if (students.ContainsKey(name))
                {
                    students[name].Comments.Add(comment);
                }

                input = Console.ReadLine();
            }

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");

                foreach (var comment in student.Value.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");
                foreach (var date in student.Value.Attends.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date.ToString(Format)}");
                }

            }
        }

    }

    public class Student
    {
        public List<DateTime> Attends { get; set; }
        public List<string> Comments { get; set; }

        public Student()
        {
            this.Attends = new List<DateTime>();
            this.Comments = new List<string>();
        }
    }
}
