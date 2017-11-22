namespace _04.Hospital
{
    using System;

    public class Hospital
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());

            int periodForChech = 3;
            int numberOfDoctors = 7;
            int treatedPatients = 0;
            int untreatedPatients = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % periodForChech == 0)
                {
                    if (untreatedPatients > treatedPatients)
                    {
                        numberOfDoctors++;
                    }
                }

                int patiensTotal = int.Parse(Console.ReadLine());

                for (int d = 0; d < numberOfDoctors && patiensTotal > 0; d++)
                {
                    patiensTotal--;
                    treatedPatients++;
                }

                untreatedPatients += patiensTotal;

            }

            Console.WriteLine(string.Format("Treated patients: {0}.", treatedPatients));
            Console.WriteLine(string.Format("Untreated patients: {0}.", untreatedPatients));
        }
    }
}