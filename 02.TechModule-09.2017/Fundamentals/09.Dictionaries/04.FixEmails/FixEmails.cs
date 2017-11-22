namespace _04.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        static void Main()
        {

            var emails = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name.Equals("stop"))
                {
                    foreach (var contact in emails)
                    {
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    }

                    break;
                }

                var email = Console.ReadLine();

                if (!(email.ToLower().EndsWith("us") || email.ToLower().EndsWith("uk")))
                {
                    if (emails.ContainsKey(name))
                    {
                        emails[name] = email;
                    }
                    else
                    {
                        emails.Add(name, email);
                    }
                }
            }
        }
    }
}