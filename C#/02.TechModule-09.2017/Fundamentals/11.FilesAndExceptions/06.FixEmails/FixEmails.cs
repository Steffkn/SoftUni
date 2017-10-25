namespace _04.FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FixEmails
    {
        public const string inputFilePath = "input.txt";
        public const string outputFilePath = "output.txt";

        static void Main()
        {
            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(new FileStream(inputFilePath, FileMode.Open)))
                {
                    var emails = new Dictionary<string, string>();

                    while (true)
                    {
                        var name = reader.ReadLine();

                        if (name.Equals("stop"))
                        {
                            foreach (var contact in emails)
                            {
                                writer.WriteLine($"{contact.Key} -> {contact.Value}");
                            }

                            break;
                        }

                        var email = reader.ReadLine();

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
    }
}