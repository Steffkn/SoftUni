namespace _02.Company
{
    using System;

    public class Company
    {
        static void Main()
        {
            var hoursNeededForProject = int.Parse(Console.ReadLine());
            var daysThatCompanyHave = double.Parse(Console.ReadLine());
            var numberOfEmployeesWorkingOverTime = int.Parse(Console.ReadLine());

            double workingHours = daysThatCompanyHave - (daysThatCompanyHave * 10) / 100;
            double totalWorkingHours = workingHours * 8 + (numberOfEmployeesWorkingOverTime * 2) * daysThatCompanyHave;
            double remeiningTime = totalWorkingHours - hoursNeededForProject;

            if (remeiningTime >= 0)
            {
                Console.WriteLine(string.Format("Yes!{0} hours left.", Math.Floor(remeiningTime)));
            }
            else
            {
                Console.WriteLine(string.Format("Not enough time!{0} hours needed.", Math.Ceiling(remeiningTime * -1)));
            }
        }
    }
}