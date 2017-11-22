namespace _06.ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        static void Main()
        {
            string userValidatorPattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}$";
            string userSpliter = @"[ /\\()]";
            Regex userFinder = new Regex(userSpliter);
            Regex userValidator = new Regex(userValidatorPattern);
            string[] users = userFinder
                .Split(Console.ReadLine())
                .Where(s => s != String.Empty)
                .ToArray();

            List<string> validUsers = new List<string>();

            foreach (var user in users)
            {
                if (userValidator.IsMatch(user))
                {
                    validUsers.Add(user);
                }
            }

            int maxLenght = 0;
            int maxLenghtIndex = 0;
            for (int i = 0; i < validUsers.Count - 1; i++)
            {
                if (validUsers[i].Length + validUsers[i + 1].Length > maxLenght)
                {
                    maxLenght = validUsers[i].Length + validUsers[i + 1].Length;
                    maxLenghtIndex = i;
                }
            }

            Console.WriteLine(validUsers[maxLenghtIndex]);
            Console.WriteLine(validUsers[maxLenghtIndex + 1]);
        }
    }
}