namespace _08.UseYourChainsBuddy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        static void Main()
        {
            string tagFinderPattern = @"(<p>)(.*?)(<\/p>)";
            Regex tagFinder = new Regex(tagFinderPattern);

            string tagFilterPattern = @"[^a-z0-9]";
            Regex tagFilter = new Regex(tagFilterPattern);

            string input = @"<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>";

            List<string> tagsContent = tagFinder
                .Matches(input)
                .Cast<Match>()
                .Select(x => x.Groups[2].Value)
                .ToList();

            for (int i = 0; i < tagsContent.Count; i++)
            {
                var buffString = String.Join(" ", tagFilter.Split(tagsContent[i]).Where(s => s != string.Empty).ToArray());
                string result = string.Empty;

                foreach (var ch in buffString)
                {
                    if (ch >= 'a' && ch <= 'm')
                    {
                        char newCh = (char)(ch + 13);
                        result = result + newCh;
                    }
                    else if (ch >= 'n' && ch <= 'z')
                    {
                        char newCh = (char)(ch - 13);
                        result = result + newCh;
                    }
                    else
                    {
                        result = result + ch;
                    }
                }

                tagsContent[i] = result;
            }

            Console.WriteLine(String.Join(" ", tagsContent));
        }
    }
}