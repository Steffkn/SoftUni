namespace _07.QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class QueryMess
    {
        static void Main()
        {
            string queryValidatorPattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}$";
            Regex queryValidator = new Regex(queryValidatorPattern);

            string querySplitter = @"[\&\?]";
            Regex queryFinder = new Regex(querySplitter);

            var valuesDict = new Dictionary<string, List<string>>();

            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine.Equals("END"))
                {
                    break;
                }

                valuesDict.Clear();

                var values = queryFinder.Split(inputLine).Where(x => x.Contains('='));

                foreach (var value in values)
                {
                    var args = value.Split('=');

                    string valueName = String.Join(" ",args[0].Replace("+", " ").Replace("%20", " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    string valueValue = String.Join(" ", args[1].Replace("+", " ").Replace("%20", " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                    if (!valuesDict.ContainsKey(valueName))
                    {
                        valuesDict.Add(valueName, new List<string>());
                    }

                    valuesDict[valueName].Add(valueValue);
                }

                foreach (var variable in valuesDict)
                {
                    Console.Write(string.Format("{0}=[{1}]", variable.Key, String.Join(", ", variable.Value)));
                }
                Console.WriteLine();
            }
        }
    }
}