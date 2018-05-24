namespace P06.Twitter.Models
{
    using P06.Twitter.Interfaces;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
