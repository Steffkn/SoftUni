namespace _04.AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AverageGrades
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                students.Add(new Student(input[0], input.Skip(1).Select(double.Parse).ToList()));
            }

            students
                .Where(x => x.Average >= 5.00)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average)
                .ToList()
                .ForEach(x => Console.WriteLine("{0} -> {1:f2}", x.Name, x.Average));
        }
    }

    public class Student
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public double Average
        {
            get
            {
                return Grades.Average();
            }
        }

        public Student(string name, List<double> grades)
        {
            this.Name = name;
            this.Grades = grades;
        }
    }
}
