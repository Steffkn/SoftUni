namespace _09.PasswordGuess
{
    using System;

    public class PasswordGuess
    {
        static void Main()
        {
            var passGuess = Console.ReadLine();
            string password = "s3cr3t!P@ssw0rd";

            if (passGuess.Equals(password))
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
