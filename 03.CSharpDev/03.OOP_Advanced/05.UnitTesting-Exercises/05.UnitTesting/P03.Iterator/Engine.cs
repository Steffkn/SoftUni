namespace P03.Iterator
{
    using System;
    using P03.Iterator.Interfaces;

    public class Engine
    {
        private IListIterator listIterator;

        public Engine(IListIterator listIterator)
        {
            this.listIterator = listIterator;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(InterpretCommand(input));
            }
        }

        public string InterpretCommand(string input)
        {
            string result = string.Empty;
            try
            {
                switch (input)
                {
                    case "HasNext":
                        result = listIterator.HasNext().ToString();
                        break;
                    case "Print":
                        result = listIterator.Print();
                        break;
                    case "Move":
                        result = listIterator.Move().ToString();
                        break;
                }
            }
            catch (InvalidOperationException ie)
            {
                result = ie.Message;
            }
            catch (ArgumentNullException anulle)
            {
                result = anulle.Message;
            }
            catch (ArgumentOutOfRangeException aoutre)
            {
                result = aoutre.Message;
            }

            return result;
        }
    }
}
