using System;
using System.Net;
using System.Text.RegularExpressions;

namespace P02.ValidateURL
{
    public class ValidateURL
    {
        public static void Main()
        {
            string inputUrl = @"https://softuni.bg:443/search?Query=pesho&Users=true#go";// Console.ReadLine();
            var url = WebUtility.UrlDecode(inputUrl);
            string invalidUrl = "Invalid URL";

            /*
             * not    https://mysite:80/demo/index.aspx
             * not    somesite.com:80/search?
             * not    https/mysite.bg?id=2
             * match  http://mysite.com:80/demo/index.aspx
             * match  http://www.mysite.com:80/demo/index.aspx
             * match  http://www.mysite.com:80/demo/index.aspx#adasd
             * match  https://my-site.bg
             * match  https://mysite.bg/demo/search?id=22o#go
             * match  https://mysite.bg:80/demo/search?id=22o#go
             * match  https://mysite.bg/demo/search?id=22o&name=yoyo#go
            */
            string pattern = @"^(?:(?'protocol'https?):\/\/(?:(?'subdomain'www)\.)?(?'domain'[a-zA-Z0-9-.]*)\.(?'tld'[a-zA-Z0-9-]*)(?::(?'port'80|443))?(?'path'[^:0-9*]?\/(?:[^\/]+)\/(?:[^\/]+\?)?)?(?:(?'query'.*\=[^#]*)&?)*(?'file'.*?)(?'fragment'\#.*)?)$";
            // string pattern2 = @"^(?:(?'protocol'https?):\/\/(?:(?'subdomain'www)\.)?(?'domain'[a-zA-Z0-9-.]*)\.(?'tld'[a-zA-Z0-9-]*)(?::(?'port'80|443))?(?'path'\/.+(?:\/|\?))*(?'file'[^.]*\.[^.]*?)?(?:(?'query'\?.*\=[^#]*)&?)*(?'fragment'\#.*)?)$";
            Regex reg = new Regex(pattern);

            var parsed = reg.Match(url);

            var portValue = parsed.Groups["port"].Value;
            if (!string.IsNullOrEmpty(portValue))
            {
                if ((parsed.Groups["protocol"].Value == "https" && portValue != "443")
                    || (parsed.Groups["protocol"].Value == "http" && portValue != "80"))
                {
                    Console.WriteLine(invalidUrl);
                    return;
                }
            }

            if (parsed.Groups["path"].Value.StartsWith(':')
                || parsed.Groups["query"].Value.StartsWith(':')
                || parsed.Groups["fragment"].Value.StartsWith(':'))
            {
                Console.WriteLine(invalidUrl);
                return;
            }

            foreach (Group group in parsed.Groups)
            {
                if (group.Value != string.Empty)
                {
                    Console.WriteLine("{0}: {1}", group.Name == "0" ? "url" : group.Name, group.Value);
                }
            }
        }
    }
}
