namespace _05.KeyReplacer
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class KeyReplacer
    {
        static void Main()
        {
            Regex keyFinder = new Regex(@"[<|\\]");

            string[] keys = keyFinder.Split(Console.ReadLine());
            string text = Console.ReadLine();

            char[] startKey = keys[0].ToCharArray();
            char[] endKey = keys[keys.Length - 1].ToCharArray();

            string startKeyPatern = "[" + String.Join("][", startKey) + "]";
            string endKeyPatern = "[" + String.Join("][", endKey) + "]";

            string patter = String.Format("{0}(.*?){1}", startKeyPatern, endKeyPatern);

            Regex textFinder = new Regex(patter);


            if (textFinder.IsMatch(text))
            {
                var result = textFinder.Matches(text).Cast<Match>().Select(x=>x.Groups[1].Value).ToArray();
                Console.WriteLine(String.Join("", result));
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}