namespace _08.EmployeeData
{
    using System;

    public class EmployeeData
    {
        static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            byte age = Convert.ToByte(Console.ReadLine());
            char genderChar = Console.ReadLine()[0];
            long personalID = 8306112507;
            int uniqueEmployeeNumber = 27563571;

            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {lastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {genderChar}");
            Console.WriteLine($"Personal ID: {personalID}");
            Console.WriteLine($"Unique Employee number: {uniqueEmployeeNumber}");
        }
    }
}
