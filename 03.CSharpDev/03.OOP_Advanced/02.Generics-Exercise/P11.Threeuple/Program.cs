using P11.Threeuple.Models;
using System;

namespace P11.Threeuple
{
    public class Program
    {
        public static void Main()
        {
            var personWithAddress = GetPersonInfo();
            Console.WriteLine(personWithAddress);

            var personWithBeer = GetPersonWithBeer();
            Console.WriteLine(personWithBeer);

            var tupleOfIntAndDouble = GetTupleOfIntAndDouble();

            Console.WriteLine($"{tupleOfIntAndDouble.Item1} -> {tupleOfIntAndDouble.Item2:G29} -> {tupleOfIntAndDouble.Item3}");
        }

        private static Threeuple<string, string, string> GetPersonInfo()
        {
            var inputArgs = Console.ReadLine().Split(' ');
            var fullName = $"{inputArgs[0]} {inputArgs[1]}";
            var address = inputArgs[2];
            var town = inputArgs[3];

            var personTuple = new Threeuple<string, string, string>(fullName, address, town);
            return personTuple;
        }

        private static Threeuple<string, int, bool> GetPersonWithBeer()
        {
            var inputArgs = Console.ReadLine().Split(' ');
            var personName = inputArgs[0];
            var beerAmount = int.Parse(inputArgs[1]);
            var isDrunk = inputArgs[2].Equals("drunk");

            var personTuple = new Threeuple<string, int, bool>(personName, beerAmount, isDrunk);
            return personTuple;
        }

        private static Threeuple<string, decimal, string> GetTupleOfIntAndDouble()
        {
            var inputArgs = Console.ReadLine().Split(' ');
            var personName = inputArgs[0];
            var doubleValue = decimal.Parse(inputArgs[1]);
            var bankName = inputArgs[2];

            var tupleOfIntAndDouble = new Threeuple<string, decimal, string>(personName, doubleValue, bankName);
            return tupleOfIntAndDouble;
        }
    }
}
