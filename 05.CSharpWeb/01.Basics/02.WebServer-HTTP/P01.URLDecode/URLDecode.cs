using System;
using System.Net;

namespace P01.URLDecode
{
    public class URLDecode
    {
        public static void Main()
        {
            var inputUrl = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(inputUrl);
            Console.WriteLine(decodedUrl);
        }
    }
}
