namespace P10.Tuple
{
    using System;
    using System.Linq;
    using P10.Tuple.Models;

    public class Program
    {
        public static void Main()
        {
            var personWithAddress = GetPersonInfo();
            Console.WriteLine(personWithAddress);

            var personWithBeer = GetPersonWithBeer();
            Console.WriteLine(personWithBeer);

            var tupleOfIntAndDouble = GetTupleOfIntAndDouble();
            Console.WriteLine(tupleOfIntAndDouble);
        }

        private static Models.Tuple<string, string> GetPersonInfo()
        {
            var inputArgs = Console.ReadLine().Split(' ');
            var fullName = $"{inputArgs[0]} {inputArgs[1]}";
            var address = inputArgs[2];

            var personTuple = new Models.Tuple<string, string>(fullName, address);
            return personTuple;
        }

        private static Models.Tuple<string, int> GetPersonWithBeer()
        {
            var inputArgs = Console.ReadLine().Split(' ');
            var personName = inputArgs[0];
            var beerAmount = int.Parse(inputArgs[1]);

            var personTuple = new Models.Tuple<string, int>(personName, beerAmount);
            return personTuple;
        }

        private static Models.Tuple<int, double> GetTupleOfIntAndDouble()
        {
            var inputArgs = Console.ReadLine().Split(' ');
            var intValue = int.Parse(inputArgs[0]);
            var doubleValue = double.Parse(inputArgs[1]);

            var tupleOfIntAndDouble = new Models.Tuple<int, double>(intValue, doubleValue);
            return tupleOfIntAndDouble;
        }
    }
}
